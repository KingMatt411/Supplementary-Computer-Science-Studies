# Linux Filesystem

### Overview

The Linux filesystem is organised hierarchically, starting with the **root directory** (`/`). All files and directories in the system are located under the root directory, regardless of their physical location (e.g., different drives, partitions, or network locations). This differs to the Windows filesystem, where different drives and partitions are logically separated using letter names (e.g., `C:`, `D:`).

### Top-Level Directories

#### `/bin` (Symlink to `/usr/bin`)

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

#### `/sbin` (Symlink to `/usr/sbin`)

* Contains essential system binaries, typically for administrative tasks, such as `fsck` (filesystem check), `reboot`, and `ip` (network managing and monitoring utility).
* Only the root user generally uses these.

#### `/lib` (Symlink to `/usr/lib`) - Shared Libraries

* The `/usr/lib` directory contains **shared libraries** for binaries contained in `/usr/bin` and `/usr/sbin`.

* A **shared library** is a collection of compiled code that can be dynamically linked and used by multiple programs simultaneously. Instead of embedding common functionality directly into an application's binary (static linking), shared libraries allow programs to share the same code at runtime, reducing duplication and saving disk and memory space.

  The key features of shared libraries include:

  * **Reusable code**
  * **Dynamic linking**
  * **Efficiency**

  Some commonly used shared libraries include:

  * **C Standard Library (`libc.so`)**: Provides core functions like `printf()`, `malloc()`, and file operations.
  * **Graphics Libraries (`libgl.so`)**: Used for rendering graphics (e.g., OpenGL).
  * **Network Libraries (`libssl.so`)**: Enables secure communication via SSL/TLS.



#### `/usr`

* The `/usr` directory is now (after the /usr merge) the primary location for all system-wide software and libraries, whether they are essential for the system or non-essential. The root (`/`) directory remains minimal, serving primarily as the base mount point and container for essential directories like `/etc`, `/dev`, and `/proc`.

##### Important `/usr` Subdirectories in a Merged Filesystem

1. **`/usr/bin`**: Consolidates all binaries from both `/bin` (essential binaries) and `/usr/bin` (non-essential binaries).
2. **`/usr/sbin`**: Consolidates administrative binaries previously in `/sbin` and `/usr/sbin`.
3. **`/usr/lib`**: Consolidates shared binaries previously in `/lib` and `/usr/lib`, used by binaries in `/usr/bin` and `/usr/sbin`.



























