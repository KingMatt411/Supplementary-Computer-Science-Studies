# Static and Dynamic Libraries

### Overview of Libraries

Libraries refer to collections of pre-written code that developers can use to enhance the functionality of their programs without reinventing the wheel. Libraries fall into two primary categories: **dynamic libraries** and **statically linked libraries**. These types of libraries differ in several ways, including:

* File formats
* How they are stored
* How they are linked
* Usage during runtime
* Packaging and deployment

Libraries consist of functions/methods, classes, and data structures that can be invoked or used by an application during development or runtime.

Libraries play a pivotal role in modular programming by separating commonly used code into centralised modules. This modularity simplifies development, reduces redundancy, and improves code maintainability.

___

## Static Libraries

To understand static libraries, including how they are written, compiled, linked, and executed (from creation to deployment), there are a couple of background things to understand.

##### Object Files

Object files are intermediate binary files generated during the compilation phase of building a program. They contain machine code for individual source files, but they are not standalone executables (that is, they  do not have an entry point [like a `main` method] and must be called from an active process [executable file]. Object files are created as a result of translating (compiling) source code (e.g., `.c`, `.cpp`) into machine code.

##### Library Archive

A library archive (`.a`) is simply an archive (like a `.tar`) of related object (`.o`) files that have been bundled together. A static library will ultimately be linked and embedded within an executable, while a dynamic library will not (but rather will be called dynamically during runtime).

### Workflow Example

Below is an outline of the steps involved in the creation of a library from writing source code up to the final build and release:

* **Scenario**: A simple utility is written (`main.c`) and uses a user-defined library containing a variety of mathematical functions. The library consists of the source code in the files `addition.c`, `subtraction.c`, `multiplication.c`, and `division.c`.

* **Steps**:

  1. **Compilation**: Each of the files in the application (including both the main source code and the library) are compiled into machine code object files (`main.o`, `addition.o`, `subtraction.o`, `multiplication.o`, and `division.o`).

     This may be done using the following commands:

     ```
     gcc -c addition.c -o addition.o
     gcc -c subtraction.c -o subtraction.o
     gcc -c multiplication.c -o multiplication.o
     gcc -c division.c -o division.o
     gcc -c main.c -o main.o
     ```

     *The `-c` flag tells `gcc` to compile the file without linking, and the `-o` flag specifies the output file name.*

  2. **Archiving Object Files into Static Library**: To create a static library, the object files for the library code are bundled into a single archive file (`libmath.a`) using the `ar` (archiver) command.

     ```
     ar rcs libmath.a addition.o subtraction.o multiplication.o division.o
     ```

     * **`ar`**: The archiver tool.
     * **`r`**: Inserts files into the archive, replacing older versions if they exist.
     * **`c`**: Creates the archive if it doesn't exist.
     * **`s`**: Adds an index to the archive for faster access by the linker.

     ###### Library Archive

     The resulting file `libmath.a` is a single archive that contains the object files `addition.o`, `subtraction.o`, `multiplication.o`, and `division.o`. `libmath.a` is a **permanent development artifact**, meant for reuse across projects. Developers typically store this in their development environment or share it as part of a library distribution.

     ###### Deletion of Object Files

     Object files are typically ephemeral and discarded after the build unless retained for debugging or incremental builds, so they will often be discarded at this point.

  3. **Linking the Static Library with the Main Application**: The linker combines the application-specific code (`main.o`) with the static library (`libmath.a`) to produce the final executable.

     ```
     gcc main.o -L. -lmath -o myprogram
     ```

     * **`-L.`**: Specifies the directory (`.` means the current directory) where the static library is located.
     * **`-lmath`**: Links the `libmath.a` library (the `lib` prefix and `.a` suffix are implicit).
     * **`-o myprogram`**: Specifies the name of the output executable.

     The final executable (`myprogram`) contains the binary code for `main.o` and the specific parts of `libmath.a` that are used by the program (selective linking*).

  4. **Final Release**:

     * **`myprogram`** is distributed to the user.

     * **`libmath.a`** remains with the developer for future reuse but is not required by the user (due to it being embedded in the final executable).

  5. **Additional Points**:

     * **Selective Linking**: During linking, the linker extracts only the necessary object files from the library archive (`libmath.a`). For example, if `main.c` only uses addition and subtraction, then only `addition.o` and `subtraction.o` are linked into the executable. The unused object files (`multiplication.o` and `division.o`) are ignored.

       Selective linking is **implicitly** performed by the linker, and it automatically includes only the parts of the library that are **explicitly referenced in your program**.

     * **Archiving Process**: The archiving process simply bundles the object files in to a single, convenient package (`libmath.a` in this example). This file is not compressed and does not alter the object files, it just organises them for easier management and linking.

     * **Reusability**: `libmath.a` can now be reused in other projects without needing to recompile the source code (`addition.c`, `subtraction.c`, etc.). Developers can link other applications with `libmath.a` to include the same functionality.

  ##### Additional Note: Libraries Independent of Programs

  While the example provided involves creating both a library (`libmath.a`) and a program (`myprogram`) together, it is important to note that **libraries are often developed independently** of any specific program. Libraries may be designed as **reusable components** that are compiled and archived without knowledge of how or where they will be used in the future.

  ##### Additional Note: Why Create Separate Libraries for Personal Projects?

  At first glance, creating and using libraries in a personal project may seem redundant, since you already have access to the source code. However, there are several reasons for organising your code into libraries, even for small, self-contained projects.

  1. **Code Reusability**: By organising reusable functionality into a library, you make it easier to include that functionality into future projects without copying and pasting source code.
  2. **Modular Development**: Libraries can help you separate your code into logical modules, making your code easier to read, maintain, and debug.
  3. **Faster Build Times**: When working on a project with multiple components, compiling the entire source code each time can be slow. By using libraries, you only need to recompile the parts of your project that have changed.
  4. **Experimenting and Prototyping**: If you have a stable library, you can prototype new ideas in your main project without worrying about breaking the core functionality in the library.

___

## Dynamic Libraries

### Overview

Dynamic libraries are collections of reusable code that are **loaded into memory at runtime**, as opposed to being embedded into an executable during the linking process (as is the case with static libraries). They provide a mechanism for different programs to share common functionality without the need to recompile or embed the library code directly into each executable.

Dynamic libraries are often referred to as **shared libraries** because multiple programs can load and use them simultaneously. 

Dynamic libraries have several advantages over static libraries, including reduced executable size, the ability to update the library independently of the application, and memory efficiency. However, they also introduce potential challenges, such as dependency management and versioning conflicts.

### Key Characteristics

1. **Not Embedded in Executable**: Unlike static libraries, dynamic libraries are **not incorporated into the final executable**. Instead, they are loaded into memory by the operating system when the program is run.
2. **Shared Across Applications**: A single copy of the library in memory can be shared by multiple applications, reducing memory usage and improving system performance.
3. **Independent Deployment**: Dynamic libraries are distributed separately from the executable. This allows for easier updates or bug fixes without needing to recompile the application.

### Workflow Example

Below is an example of how a dynamic library is created, used, and deployed.

* **Scenario**: The same `main.c` program uses a user-defined dynamic library containing mathematical functions (`addition.c`, `subtraction.c`, `multiplication.c`, and `division.c`).

* **Steps**:

  1. **Compilation of Source Code Into Object Files**: As with static libraries, the source code for both the application and library is first compiled into object files. This step is identical to the static library process.

     ```
     gcc -c addition.c -o addition.o
     gcc -c subtraction.c -o subtraction.o
     gcc -c multiplication.c -o multiplication.o
     gcc -c division.c -o division.o
     gcc -c main.c -o main.o
     ```

     

  2. **Creating the Dynamic Library**: Instead of archiving the object files into a `.a` archive, they are compiled into a **shared object** file (`libmath.so`). This is done using `gcc` with the `-shared` flag to indicate that the output is a shared library.

     ```
     gcc -shared -o libmath.so addition.o subtraction.o multiplication.o division.o
     ```
  
     The resulting file, `libmath.so`, is the resulting library containing the compiled functions.

     
  
     ###### Comparison of Shared Objects (Dynamic Libraries) and Archives (Static Libraries)
  
     While static libraries are collections (archives) of independent object files (`.o`) grouped together into an archive using tools like `ar`, shared libraries are **compilations** of multiple object files into a single, cohesive object file (`.so`). These libraries are not mere archives but aggregated units that:
  
     * Include **position-independent code (PIC)** for runtime relocatability.
     * Merge the object files into a unified codebase with additional metadata, such as **dynamic symbol tables** and **relocation entries**.
     * Support runtime linking, enabling the operating system to resolve symbols and load only the required sections into memory.
  
     Several of the above terms may be unfamiliar, so are explained below:
  
     * **Demand Paging**: A memory management technique where only the parts of a program or library that are actively accessed are loaded into memory, reducing resource usage by leaving unused parts on disk. Demand paging is used when dynamically loading code from shared libraries into memory.
     * **Dynamic Symbol Tables**: Specialised data structures in shared libraries that store information about exported functions and variables, allowing the dynamic linker to resolve references at runtime.
     * **Position-Independent Code (PIC)**: A type of compiled code that uses relative addressing rather than absolute memory addresses, enabling the code to be loaded at any memory location without modification/relocation.
     * **Relocation Entries**: Metadata in compiled code that indicates places where addresses need adjustment during linking or loading to resolve symbols or accommodate runtime memory locations.
  
     
  
  3. **Linking the Dynamic Library with the Application**: The linker creates the executable (`myprogram`) by linking it with the dynamic library. However, unlike static libraries, the dynamic library is not embedded in the executable.
  
     ```
     gcc main.o -L. -lmath -o myprogram
     ```
  
     * **`-L.`**: Specifies the location of `libmath.so`.
     * **`-lmath`**: Links the dynamic library (similar to static libraries).
  
     At this stage, the executable contains **references** to the dynamic library but not the library code itself. These references include the library name and the specific symbols (functions) it uses.
  
     
  
  4. **Running the Application**: When the program is executed, the operating system dynamically loads `libmath.so` into memory and resolves the references to the library functions. If the dynamic library is not available at runtime, the program will fail to run.
  
     
  
  5. **Deployment**: The executable (`myprogram`) and the dynamic library (`libmath.so`) must be distributed together, or the library must be pre-installed in a location where the system loader can find it.



### Dynamic Linking and Loading Behaviour

1. **Runtime Linking**:
   * Dynamic libraries are linked at runtime by the **dynamic linker/loader**, a component of the operating system responsible for loading shared libraries into memory and resolving symbol references.
   
   * On Linux, the dynamic linker is typically `ld.so` or `ld-linux.so`.
   
2. **Search Paths**:

   * The loader searches for dynamic libraries in specific directories. These directories are defined by:
     * The **default system library paths** (e.g., `/lib`, `/usr/lib`).
     * The `LD_LIBRARY_PATH` **environment variable**, which allows developers to specify custom search paths.

3. **Versioning**:

   * Dynamic libraries support versioning, allowing multiple versions of a library to coexist. Programs can specify the required version of a library to ensure compatibility.

4. **Lazy Loading**:

   * Many systems use lazy loading for dynamic libraries, meaning the library code is loaded into memory only when it is first used by the application.



### Advantages of Dynamically Linked Libraries

1. **Reduced Size**:
   * Executables are smaller because they do not contain the library code. Only the necessary references are included.
2. **Memory Efficiency**:
   * A single copy of the library is shared across applications, reducing memory usage.
3. **Easy Updates**:
   * Developers can update or patch the library independently of the application. Applications automatically use the updated library the next time they run.
4. **Flexibility**:
   * Applications can dynamically load libraries at runtime (using functions like `dlopen()` on Linux), enabling plugin architectures and modular designs.



### Challenges of Dynamic Libraries

1. **Dependency Management**: Applications may fail to run if the required dynamic libraries are missing or incompatible with the program.
2. **Version Conflicts**: A phenomenon known as "dependency hell" can occur when multiple programs require different versions of the same library.
3. **Performance Overhead**: Loading libraries at runtime introduces a small performance overhead compared to static libraries.
4. **Complex Deployment**: Distributing applications with dynamic libraries requires careful packaging to ensure the necessary libraries are available on the target system.



___



## Additional Notes

### Object Files

The term **object file** originates from historical computing terminology rather than the concept of "objects" in object-oriented programming (OOP).

1. **Historical Reasoning**:
   * In early computing, "object" referred to a tangible, intermediate product of the compilation process. 
   * An "object" in this context can be thought of in a somewhat general sense, an entity created by processing something. In this case, it is a compiled but incomplete product of source code.
2. **Intermediate Representation**:
   * Object files are an **incomplete product** between source code and a final executable. They are not yet "complete" but represent a tangible output of the compiler that can later be linked into a larger program or library.

### Key Differences Table

| Feature               | Static Libraries (`.a`)            | Shared Libraries (`.so`)                                     |
| --------------------- | ---------------------------------- | ------------------------------------------------------------ |
| **Structure**         | Collection (archive) of `.o` files | Single aggregated `.so` file                                 |
| **Linking Time**      | At compile/link time               | At runtime                                                   |
| **Memory Usage**      | Each program has its own copy      | Shared across programs                                       |
| **Symbol Resolution** | Done by the linker at compile time | Done dynamically by the OS loader (`ld.so`) using demand paging |
| **Flexibility**       | Requires recompilation for updates | Allows independent updates to the library code               |



### Cross-Platform File Types and Utilities

##### File Types and Extensions

| File Type             | Linux                    | macOS                                                | Windows                         |
| --------------------- | ------------------------ | ---------------------------------------------------- | ------------------------------- |
| **Source Code**       | `.c`, `.h`, `.cpp`, etc. | `.c`, `.h`, `.cpp`, etc.                             | `.c`, `.h`, `.cpp`, etc.        |
| **Object Files**      | `.o`                     | `.o`                                                 | `.obj`                          |
| **Static Libraries**  | `.a`                     | `.a`                                                 | `.lib`                          |
| **Dynamic Libraries** | `.so`                    | `.dylib` (or `.so` for cross-platform compatibility) | `.dll` (dynamic link libraries) |
| **Executables**       | No specific extension    | No specific extension (same as Linux)                | `.exe`                          |

##### Compilers/Tools

| Utility      | Linux                                                        | macOS                             | Windows                    |
| ------------ | ------------------------------------------------------------ | --------------------------------- | -------------------------- |
| **Compiler** | `gcc` (GNU Compiler Collection) or `clang`                   | `clang`                           | `cl.exe` or `gcc` (MinGW)  |
| **Linker**   | `ld` (used internally by `gcc`, but can be invoked directly) | `ld` (used internally by `clang`) | `link.exe` or `ld` (MinGW) |
| **Archiver** | `ar`                                                         | `ar`                              | `lib.exe` or `ar` (MinGW)  |
