<%@ page import="app.backend.MyApp" %>
<html>
<head>
    <title>A Comment Test</title>
</head>

<body>
    <p>Today's date: <%= (new java.util.Date()).toLocaleString()%></p>
    <jsp:useBean id="appBean" class="app.backend.MyApp" />
    <jsp:setProperty name="appBean" property="name" value="My own value" />
    <jsp:getProperty name="appBean" property="name" />
</body>
</html>