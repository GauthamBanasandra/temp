import java.nio.file.Path;
import java.nio.file.Paths;

public class SystemPaths {
    public static void main(String[] args) {
        String strTmp = System.getProperty("java.io.tmpdir");
        Path path = Paths.get(strTmp);
        path = path.resolve(Paths.get("abc.txt"));
        System.out.println(path);
    }
}
