# `HTTPUrlConnection` Class

`HTTPUrlConnection` is a Java class that allows you to communicate with a web server using HTTP and HTTPS protocols. It is part of the Java Standard Library (Java API) and is included in the `java.net` package. `HTTPUrlConnection` provides a way to send and receive data over the web, making it useful for tasks such as downloading files, submitting forms, or interacting with RESTful APIs.

### Key Features of `HTTPUrlConnection`:

1. **Connection Management**: It manages the HTTP connection to a web server, handling aspects such as connecting, sending requests, receiving responses, and closing the connection.
2. **HTTP Methods**: It supports various HTTP methods like `GET`, `POST`, `PUT`, `DELETE`, `HEAD`, and others. You can set the desired method by calling the `setRequestMethod(String method)` method.
3. **Request Properties**: You can set request headers and properties using methods like `setRequestProperty(String key, String value)` to customise the HTTP request, such as setting the `User-Agent`, `Accept`, or `Content-Type`.
4. **Handling Responses**: It allows you to read the response code, message, and body from the server. You can use methods like `getResponseCode()`, `getResponseMessage()`, and `getInputStream()` to access the server's response.
5. **Streaming Support**: `HTTPUrlConnection` supports both input and output streaming, which allows you to efficiently handle large data uploads or downloads by reading and writing in chunks.
6. **Timeouts**: You can set connection and read timeouts to prevent your application from waiting indefinitely for a response by using `setConnectionTimeout(int timeout)` and `setReadTimeout(int timeout)`.
7. **Automatic Redirection**: By default, `HTTPUrlConnection` will automatically follow HTTP redirects (response codes 3xx). This behaviour can e configured using the `setInstanceFollowRedirects(boolean followRedirects)` method.

### Basic Usage Example

```java
import java.net.HttpURLConnection;
import java.net.URL;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.IOException;

public class Main {
  public static void main(String[] args) {
    try {
      // Create an object with the target URL
      URL url = new URL("https://api.example.com/data");
      
      // Open a connection to the URL
      HttpURLConnection connection = (HttpURLConnection) url.openConnection();
      
      // Set the request method to GET
      connection.setRequestMethod("GET");
      
      // Get the response code
      int responseCode = connection.getResponseCode();
      System.out.println("Response Code: " + responseCode);
      
      // Read the response if the response code is 200 (OK)
      if (responseCode == HttpURLConnection.HTTP_OK) {
        BufferedReader in = new BufferedReader(new InputStreamReader(connection.getInputStream()));
        String inputLine;
        StringBuilder response = new StringBuilder();
        
        while((inputLine = in.readLine()) != null) {
          response.append(inputLine);
        }
        in.close();
        
        // Print the response
        System.out.println("Response: " + response.toString());
      } else {
        System.out.println("GET request failed.");
      }
      
      // Disconnect the connection
      connection.disconnect();
      
    } catch (IOException e) {
      e.printStackTrace();
    }
  }
}
```



#### 1. What does `openConnection()` do under the hood?

`openConnection()` is a method provided by the `URL` class in Java. When you call `openConnection` on a `URL` object, it performs the following steps:

1. **Determine the Protocol Handler**: The method first determines the protocol (such as HTTP, HTTPS, FTP, etc.) from the URL string. Based on this protocol, it selects the appropriate protocol handler. For HTTP and HTTPS URLs, it selects the `HttpURLConnection` handler.
2. **Create a Connection Object**: Once the protocol handler is determined, `openConnection()` creates an instance of the appropriate `URLConnection` subclass (like `HttpURLConnection` for HTTP URLs).
3. **Initialise the Connection**: The method **returns this (`HttpURLConnection`) object without actually establishing the connection to the server**. The connection is only established when you call methods like `connect()`, `getInputStream()`, `getOutputStream()`, or `getResponseCode()` on the `HttpURLConnection` object.

In summary, `openConnection()` prepares the connection object for the URL's protocol but doesn't open the network connection immediately.

##### Why Does the Reference Returned by `openConnection()` Need to be Cast as an `HttpURLObject`?

Remember that **methods return references (i.e., pointers)** to objects, not actual objects. The data type returned by `openConnection()` is essentially "pointer to a `URLConnection` object", (or, if this was C++, a `URLConnection*` - bearing in mind that C++ uses its own libraries and classes for this purpose which are different to those used in Java). Due to upcasting, a `URLConnection` reference can point to an object of any of its subclasses (such as `HttpURLConnection`, `FileURLConnection`, `JarURLConnection`). . In this case, it points to an `HttpURLConnection` instance. However, since the return type of the `openConnection()` method is a reference to `URLConnection`, this reference needs to be cast as an `HttpURLCompiler` to ensure access to methods specific to `HttpURLConnection`.





































