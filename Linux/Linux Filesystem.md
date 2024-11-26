# Linux Filesystem

## Overview

The Linux filesystem is organised hierarchically, starting with the **root directory** (`/`). All files and directories in the system are located under the root directory, regardless of their physical location (e.g., different drives, partitions, or network locations). This differs to the Windows filesystem, where different drives and partitions are logically separated using letter names (e.g., `C:`, `D:`).

## Top-Level Directories

### `/bin` (Symlink to `/usr/bin`)

* In traditional Unix systems, `/bin` contained essential binaries required for booting the system and performing basic maintenance. These programs had to be accessible even if `/usr` was on a separate partition and not yet mounted during early boot.

  Traditionally, these directories contained binaries (programs) like:

  * **`/bin`**: `ls`, `cp`, and `mkdir`

  * **`/usr/bin`**: `gcc`, `nano`, etc.

  * On most Linux distributions, `/usr` is no longer kept on a separate partition. It is mounted at boot, alongside the root filesystem. Due to this, a decision known as **"the /usr merge"** was made, where the `/bin` directory is now a **symbolic link** to `/usr/bin`. This can be confirmed by running `ls -ld /bin`, which should print the following:

    ```
    lrwxrwxrwx 1 root root 7 Apr 22  2024 /bin -> usr/bin
    ```

  * The /usr merge also involved making `/sbin` and `/lib` symlinks to `/usr/sbin` and `/usr/lib` respectively.
  * A filesystem can also be identified as having undergone the /usr merge by the presence of the `/bin.usr-is-merged`, `/sbin.usr-is-merged`, and `/lib.usr-is-merged` files.

___

### `/sbin` (Symlink to `/usr/sbin`)

* Contains essential system binaries, typically for administrative tasks, such as `fsck` (filesystem check), `reboot`, and `ip` (network managing and monitoring utility).
* Only the root user generally uses these.

___

### `/lib` (Symlink to `/usr/lib`) - Shared Libraries and Program-Specific Support Files

* **Shared Libraries**: The `/usr/lib` directory contains shared libraries for binaries contained in `/usr/bin` and `/usr/sbin`.

  A **shared library** is a collection of compiled code that can be dynamically linked and used by multiple programs simultaneously. Instead of embedding common functionality directly into an application's binary (static linking), shared libraries allow programs to share the same code at runtime, reducing duplication and saving disk and memory space.

  Some commonly used shared libraries include:

  * **C Standard Library (`libc.so`)**: Provides core functions like `printf()`, `malloc()`, and file operations.
  * **Graphics Libraries (`libgl.so`)**: Used for rendering graphics (e.g., OpenGL).
  * **Network Libraries (`libssl.so`)**: Enables secure communication via SSL/TLS.

  

* **Program-Specific Support Files**: In addition to shared libraries, the `/lib` and `/usr/lib` directories contain program-specific directories containing **program-specific support files**. These may include:

  * Auxiliary binaries.
  * Plugins and modules (e.g., `/usr/lib/xorg/modules`).
  * Configuration files or support data.




___

### `/usr`

* The `/usr` directory is now (after the /usr merge) the primary location for all system-wide software and libraries, whether they are essential for the system or non-essential. The root (`/`) directory remains minimal, serving primarily as the base mount point and container for essential directories like `/etc`, `/dev`, and `/proc`.

##### Important `/usr` Subdirectories in a Merged Filesystem

1. **`/usr/bin`**: Consolidates all binaries from both `/bin` (essential binaries) and `/usr/bin` (non-essential binaries).
2. **`/usr/sbin`**: Consolidates administrative binaries previously in `/sbin` and `/usr/sbin`.
3. **`/usr/lib`**: Consolidates shared binaries previously in `/lib` and `/usr/lib`, used by binaries in `/usr/bin` and `/usr/sbin`.



___



## How Programs and Their Files are Organised on Linux, macOS, and Windows

### Linux

Programs are distributed across a hierarchical directory structure based on file type and purpose.

* **Executables** are typically stored in **`/usr/bin`** or **`/usr/local/bin`**.
* **Shared Libraries** are stored in **`/usr/lib`** or **`/usr/lib64`**.
* **Configuration Files** are stored in **`/etc`**.
* **Program-Specific Files** such as plugins or modules are organised into subdirectories under **`/usr/lib`**.

This modular approach emphasises reusability and system-wide consistency, with shared libraries often used by multiple programs. This structure, while **efficient** and **standardised**, can appear **fragmented** compared to other systems.

#### Installation Methods and Package Managers

##### Traditional Package Managers

Traditional package managers such as `apt`, `yum`, or `dnf`, install software by:

* Downloading **precompiled packages** from a centralised repository.
* Resolving and installing any **dependencies** that the program requires (e.g., shared libraries like `libsqlite3`).
* Placing files into their appropriate directories (executables into `/usr/bin`, libraries into `/usr/lib` or `/usr/lib64`, and configuration files into `/etc`).

##### Modern Containerised Package Formats

Containerised package formats like **Snap** and **Flatpak** take a different approach:

* **Self-Contained Bundles**: These packages include the application and most of its dependencies, reducing reliance on system-wide libraries.
* **Sandboxing**: Applications run in isolated environments, enhancing security and protecting the system from unintended interactions.

___

### Windows

Programs are primarily stored in dedicated directories under `C:\Program Files` (or `C:\Program Files (x86)` for 32-bit applications). Each program's directory contains its executable, libraries (`.dll` files), resources, and configurations, making them self-contained. This approach simplifies program management but can lead to duplication of shared libraries.

However, some shared libraries reside in centralised directories like `C:\Windows\System32`.

___

### macOS

#### User-Facing Applications

User-facing applications are typically distributed as `.app` bundles which encapsulate executables, resources, and libraries in a single directory, making installation and uninstallation straightforward.

#### System Utilities and Command-Line Tools

For system utilities and command-line tools, macOS uses a Linux-like structure, with:

* **Binaries** in **`/usr/bin`**
* **Libraries** in **`/usr/lib`**
* **Configurations** in **`/etc`** or **`/library`**

#### Handling Duplicate Libraries on macOS

While `.app` bundles can lead to duplication of shared libraries, the issue is often less severe compared to Windows due to differences in how dependencies are managed. macOS mitigates library duplication by encouraging the use of **system-wide frameworks** stored in `/System/Library/Frameworks` or `/Library/Frameworks`. Applications can dynamically link to these system-provided frameworks, reducing the need to bundle common libraries.

**Example: `libsqlite3.dylib`**:

* On macOS, instead of every app bundling its own version of `libsqlite3`, many applications use the system-wide version provided in `/usr/lib`. This approach prevents unnecessary duplication.

##### Dependency Handling Depends on the Installation Method

The way that dependencies are handled for a given application depends on how it is installed.

1. **Drag-and-Drop `.app` Installation**:

   * `.app` bundles typically include all the necessary dependencies, avoiding dependence on external libraries.

     If the program uses `libsqlite3`, it may bundle its own copy of the library inside the `.app` directory (e.g., in `MyApp.app/Contents/Frameworks`).

   * This approach often leads to **duplication**, as each application bundles its own copy of shared libraries.

2. **`.pkg` Installation (via Installer)**:

   * Applications installed via `.pkg` files often include a script or installer logic that can:
     * Check for existing dependencies in `/Library/Frameworks` or `/System/Library/Frameworks`.
     * Install missing frameworks or libraries if needed.
   * The installer may place common dependencies in `/Library/Frameworks` or `/usr/local/lib`. Dependencies may still be installed locally to the application's directory for simplicity or compatibility.
   * The decision of whether to share or duplicate dependencies is made by the developer.

3. **Package Managers (Homebrew, MacPorts, etc.)**:

   * Package managers like Homebrew and MacPorts handle dependencies more like Linux.
   * Dependencies are installed as shared libraries in standard locations, such as `/usr/local/lib` for Homebrew or `/opt/local/lib` for MacPorts. This includes user-facing GUI applications, such as Homebrew casks.
   * Homebrew and MacPorts focus on Unix-style shared libraries (`.dylib`) rather than macOS frameworks, because they target both developers and Unix-like workflows.

___

### Additional Notes

* **Containerisation**:

  * The practice of storing all dependencies in a program's directory (e.g., in `C:\Program Files`) is **not an example of containerisation**.

    Storing dependencies in a program-specific directory isolates each application and ensures that they work regardless of the system-wide environment, which is also done with containers. However, containers also do the following:

    * Containers (e.g., Docker containers) are isolated at the runtime level using virtualisation or sandboxing techniques. Programs in `Program Files` do not have this runtime isolation - they share the same OS processes, memory space, and kernel.
    * Containers include a standardised environment (e.g., specific OS versions or libraries). Applications in `Program Files` rely on the host OS environment and are not as portable.
    * Applications in `Program Files` are deeply integrated with the host OS (e.g., through shared DLLs [dynamically linked libraries] in `System32`), whereas containers are typically isolated and can run independently of the host system's configuration.
