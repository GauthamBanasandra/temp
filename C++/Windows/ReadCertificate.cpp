#include <Windows.h>

#include <Wincrypt.h>

#include <iostream>
#include <ostream>
#include <string>

std::string GetLastErrStr() {
  const LPTSTR lp_msg_buf = nullptr;
  const auto dw = GetLastError();

  FormatMessage(FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM |
                    FORMAT_MESSAGE_IGNORE_INSERTS,
                nullptr, dw, MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
                lp_msg_buf, 0, nullptr);

  std::string err_msg(lp_msg_buf);
  LocalFree(lp_msg_buf);
  return err_msg;
}

void PrintCertificateSubjectName(const PCCERT_CONTEXT cert) {
  const auto cb_size = CertGetNameString(cert, CERT_NAME_SIMPLE_DISPLAY_TYPE, 0,
                                         nullptr, nullptr, 0);
  if (cb_size == 0) {
    std::cout << "Unable to get the size of the cert name" << std::endl;
    return;
  }

  auto *cert_name = static_cast<LPTSTR>(malloc(cb_size * sizeof(TCHAR)));
  CertGetNameString(cert, CERT_NAME_SIMPLE_DISPLAY_TYPE, 0, nullptr, cert_name,
                    cb_size);
  std::cout << cert_name << std::endl;
  free(cert_name);
}

int main(int argc, char *argv[]) {
  const auto *subject_name = L"ClientRootCA";
  const auto *cert_store = "Root";

  auto *sys_store_handle = CertOpenSystemStore(NULL, cert_store);
  if (sys_store_handle == nullptr) {
    std::cout << "Unable to open the system certificate store" << std::endl;
    std::cout << GetLastErrStr() << std::endl;
    return 1;
  }

  const auto *cert = CertFindCertificateInStore(
      sys_store_handle, PKCS_7_ASN_ENCODING | X509_ASN_ENCODING, 0,
      CERT_FIND_SUBJECT_STR, subject_name, nullptr);

  if (cert != nullptr) {
    PrintCertificateSubjectName(cert);
    if (!CertFreeCertificateContext(cert)) {
      std::cout << "Unable to free certificate" << std::endl;
      std::cout << GetLastErrStr() << std::endl;
    }
  }

  const auto result =
      CertCloseStore(sys_store_handle, CERT_CLOSE_STORE_CHECK_FLAG);
  if (!result) {
    std::cout << "Unable to close the system certificate store" << std::endl;
  }
  return 0;
}
