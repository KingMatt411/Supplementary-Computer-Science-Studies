# C# Refresher

The following is a brief refresher of the structure of a basic "Hello, World!" application in C#, explaining how it differs from Java.

```csharp
using System;

namespace MySimpleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World");
        }
    }  
}
```

#### `using System;`

`System` is a **namespace**, which is very similar to a **package in Java**.

* A namespace in C# is a logical grouping of classes, structs, enums, delegates, and other types.
* It provides a way to organise code and avoid naming conflicts.
* `System` is the root namespace for many fundamental classes and types in the .NET framework, like `Console`, `String`, and `Math`.
* The C# `System` namespace is similar to Java's `java.lang` package. However, the latter is imported implicitly.

The **main difference** between a C# namespace and Java package is that **Java packages are tied to physical folder structures, whereas C# namespaces are not**. In Java, if a class is in the `com.example` package, it must reside in a `com/example` folder. In C#, namespaces are logical and do not dictate the physical file structure, though aligning the two is a best practice for maintainability.

##### Prefixing with Namespaces

When you import (with the `using` keyword) namespaces in C#, you can reference classes from that namespace without needing to prefix the classes with the namespace, like you would in Java. However, this can be done optionally, and is important for disambiguation if there are naming conflicts. For example:

```csharp
System.Console.WriteLine("Hello, World");
```

```csharp
Console.WriteLine("Hello, World");
```

#### `namespace MySimpleApp`

This is the namespace of the classes and types defined in the curly braces (`{}`) following its declaration. Unlike Java, which enforces a single package (namespace) per file, C# allows you to declare multiple namespaces in the same file. However, it is best practice to use a single namespace per file for clarity.

#### `class Program`

The class containing the `Main` method can be named anything, but it must be `public` or `internal`, not `private`. It is a common convention to call this class `Program`.

#### The `Main` Method (Entry Point)

The `Main` method is the entry point of the application, where execution begins. It must be named `Main` (with a capital `M`) to be recognised by the compiler.

It can have any of the following signatures:

```csharp
static void Main() {}
static void Main(string[] args) {} // `args` receives command-line arguments
static int Main() { return 0; } // Can return an int to indicate exit codes
static int Main(string[] args) { return 0; }
```



#### Java Equivalent

Below is Java code that follows the nomenclature and use of namespaces, in the C# example above, with comments explaining the differences.

Note that the naming used here (specifically `class Program`) and explicit import of `java.lang` is not normal in Java and only done to highlight its equivalency to the C# code.

```java
package com.example.MySimpleApp; // Equivalent to `namespace MySimpleApp`

import java.lang; // Equivalent to `using System`, but this is implicit in Java and not typical in real-world projects

class Program { // Same as `class Program` in C#, but this would typically be nested in the namespace

    public static void main(String[] args) {
        System.out.println("Hello, World"); // `System` is a class defined in `java.lang` of which `out` is a field of type `PrintStream`. In C#, `Console` is a class defined in the `System` namespace.
    }
}
```

