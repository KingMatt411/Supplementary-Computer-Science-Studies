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

### Static Libraries

To understand static libraries, including how they are written, compiled, linked, and executed (from creation to deployment), there are a couple of background things to understand.

##### Object Files

Object files are intermediate binary files generated during the compilation phase of building a program. They contain machine code for individual source files, but they are not standalone executables (that is, they  do not have an entry point [like a `main` method] and must be called from an active process [executable file]. Object files are created as a result of translating (compiling) source code (e.g., `.c`, `.cpp`) into machine code.

##### Library Archive

A library archive (`.a`) is simply an archive (like a `.tar`) of related object (`.o`) files that have been bundled together. A static library will ultimately be linked and embedded within an executable, while a dynamic library will not (but rather will be called dynamically during runtime).

#### Workflow Example

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

### Dynamic Libraries

