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

### `/etc` (Configuration Files)

**Purpose**: The `/etc` directory contains **system-wide** configuration files and directories for the operating system and installed applications.

**Characteristics**:

* Primarily stores text-based configuration files.
* Does not contain binaries or executable files.
* Modifying files in `/etc` typically requires root permissions.

**Examples**:

* `/etc/passwd`: User account information (not passwords, these are stored in `/etc/shadow`).
* `/etc/fstab`: Filesystem table, used to define how filesystems are mounted at boot.
* `/etc/hostname`: System hostname configuration.
* `/etc/network/interfaces`: Network interface configuration (in systems that do not use NetworkManager)
* `/etc/apt/sources.list.d/ubuntu.sources`: List of package repositories for Debian-based distributions.

**Usage**:

* Administrators edit files here to configure system behaviour, such as setting up network interfaces, configuring services, or managing user authentication.

**Caution**: Incorrect modifications to critical files (like `/etc/fstab`) can prevent the system from booting.



___

### `/home`

**Purpose**: Contains personal directories for each user on the system.

**Structure**:

* Each user gets a subdirectory named after their username (e.g., `/home/mattpatchava`).
* These directories serve as the default location for user files, configurations, and documents.
* User-specific configuration files (hidden files, starting with `.`) are stored here, such as `.bashrc`, `.vimrc`, etc.

**Shorthand Notation**: The `~` shorthand represents the current user's home directory.



***Note: System-wide configurations are stored in `/etc`, while user-specific configurations are stored as hidden files starting with `.` in the user's home directory.***



___

### `/root` (Root User's Home Directory)

**Purpose**: Home directory for the root user (system administrator).

**Separation from `/home`**: `/root` is not in `/home` to ensure root's files are accessible even if `/home` is on a separate partition that isn't mounted.



___

### `/opt` (Optional 3rd-Party Software)

**Purpose**: The `/opt` directory is designed as a location for **third-party, non-standard software that is not included in the default Linux distribution or managed by the system's package manager** (like `apt` or `dnf`). It provides a location to organise and isolate such software from the core system directories.

#### File Organisation in `/opt`

Software in `/opt` is typically self-contained.

* Binaries, libraries, and configuration files are all stored together within the specific software's directory. This is somewhat similar to `.app` bundles on macOS.

  For example, if you install `ExampleApp` manually, its directory structure might look like this:

  ```bash
  /opt/exampleapp/
  ├── bin/           # Application binaries
  ├── lib/           # Libraries used by the application
  ├── etc/           # Application-specific configuration files
  ├── share/         # Shared resources like icons, docs, etc.
  └── README         # Optional documentation
  ```



#### Package Managers vs. Manual Installation

##### Package Managers

Most Linux distributions do not use `/opt` for software installed via system package managers like `apt`, `dnf`, or `pacman`. These tools place binaries in `/usr/bin`, libraries in `/usr/lib`, and configuration files in `/etc` to integrate with the system.

For example, if you install `nginx` using `apt`, its configuration files will be in `/etc/nginx` and its binary will be in `/usr/sbin/nginx`.

##### Third-Party Installers

`/opt` is commonly used to store software downloaded directly from vendor websites or third-party sources, such as proprietary software or custom tools that aren't part of the distribution's repositories.

Examples may include VirtualBox or some custom development tools or IDEs like Android Studio.

However, if the vendor provides a `.deb` (or similar) package which you download and then install with a package manager like `apt` or `dpkg`, it will be installed in the standard Linux directories (`/bin`, `/lib`, and `/etc`). `/opt` is typically only used by 3rd-party **installers**.



___

### Mounting Drives

To understand how the upcoming directories (`/dev`, `/mnt`, and `/media`) are used, it is necessary to understand what mounting is and how it works.

#### What is Mounting a Drive?

In the context of Linux (or any Unix-like operating system), **mounting a drive** means making the filesystem on that drive accessible to the operating system and users by attaching it to the directory tree at a specific point, known as the **mount point**.

* A drive or partition is not automatically accessible when it is connected. The operating system must "mount" the drive, which essentially tells the OS:
  * Where the filesystem should appear in the file directory structure (e.g., `/mnt/usb`, `/media/<username>/<DriveName>`).
  * That the data on the drive is ready to be read from or written to.

#### How Mounting Works

1. **Drive Connection**:
   * When you plug in a USB drive or connect a hard disk, the operating system detects the hardware and creates a corresponding device **file** in `/dev` (e.g., `/dev/sdb`).
2. **Mounting**:
   * The filesystem on the device must be "attached" to a directory in the OS. This directory is the **mount point**, and the contents of the filesystem will appear inside this directory.
3. **Accessing Files**:
   * Once mounted, you can navigate to the mount point (e.g., `/mnt/usb`) and access the files as if they were part of your local filesystem.

#### Why a Drive Might Be Connected but Not Mounted

1. **Manual Mounting Required**: On some systems, removable drives like USBs are not mounted automatically. You need to mount them manually using the `mount` command.
2. **No Filesystem**: The drive may not have a recognisable filesystem, such as a blank drive, an unformatted drive, or a corrupted filesystem.
3. **Errors or Corruption**: If the filesystem is damaged, the OS may fail to mount it until it's repaired using tools like `fsck`.
4. **Permissions**: You might not have the required permissions to mount a drive, especially in multi-user or secured environments.
5. **Automounting Disabled**: Automounting might be disabled on purpose for security or system policy reasons.

#### Comparison to macOS "Eject"

When a USB drive appears on your Desktop or Finder sidebar, it is **mounted**. You can read/write files and interact with the drive. When you drag a drive to the Trash (which changes to an Eject icon), macOS **unmounts** the drive. This detaches the filesystem from the OS and ensures all pending writes are completed.



___

### `/dev` (Device Files)

**Purpose**: Contains special device files representing hardware devices and virtual filesystems.

**Examples**:

* `/dev/sda`: Represents the first hard disk.
* `/dev/null`: Discard output to nowhere.
* `/dev/tty`: Terminal interfaces.

**Note**: These files are dynamically created by the system and used to interact with hardware.



___

### `/mnt` (Mount Points for Temporary File Systems)

**Purpose**: `/mnt` is a generic location for manually mounting filesystems (e.g., external drives, ISO images). It is **not used automatically** by the system - administrators must manually create subdirectories and use the `mount` command.

**Example Usage**:

```bash
sudo mount /dev/sdb1 /mnt
```

**Key Characteristics**:

* `/mnt` is an **empty directory by default** and contains no subdirectories unless created manually.
* `/mnt` is used mostly in scripts, temporary experiments, or troubleshooting to avoid polluting `/media`.



___

### `/media` (Automounted Media)

To understand the following information, one should be familiar with the concept of mounting/unmounting drives. This process is explained in the `/mnt` section of this file.

**Purpose**:

* A **dynamic mount point** for removable media, such as USB drives, CDs/DVDs, or external hard drives.
* Modern Linux distributions with desktop environments (like GNOME or KDE) **automatically mount** removable devices removable devices under `/media/<username>/<device-label>` when connected.

**Example Usage**: Insert a USB drive, and it gets automatically mounted to:

```bash
/media/mattpatchava/MyUSB
```

**Characteristics**:

* `/media` is managed by the system, typically through tools like `udev` or desktop utilities.
* Subdirectories (e.g., `/media/mattpatchava/`) are created dynamically and removed when the media is ejected.



___

### `/cdrom` (Legacy Mount Point)

**Purpose**: Historically used as a mount point for CD-ROM drives.

**Note**: Modern systems typically use `/media` for mounting removable media, including CDs.



___

### `swap.img` (Swap File)

**Purpose**: A file used for swap space, which acts as virtual memory when physical RAM is full.

**Usage**:

* Configured in `/etc/fstab`.
* Modern systems often use a dedicated swap partition instead of a swap file.



___

### `/var` (Variable Files)

**Purpose**: Stores files that are expected to change frequently during system operation.

**Subdirectories**:

* `/var/log`: System and application logs (e.g., `/var/log/syslog`, `/var/log/dmesg`).
* `/var/spool`: Temporary data awaiting processing (e.g., print jobs in `/var/spool/cups`).
* `/var/tmp`: Temporary files that persist across reboots, unlike `/tmp`.
* `/var/www`: Default location for web server files (e.g., Apache, Nginx).

**Example**: You can check the system logs using `less /var/log/syslog`.



___

### `/tmp` (Temporary Files)

**Purpose**: A temporary directory for files created by applications or users.

**Characteristics**: Files here are typically deleted on reboot or after a set time.

**Usage**:

* Applications use `/tmp` for temporary storage during runtime.
* Users can manually create temporary files for short-term use.

**Caution**: Avoid storing critical data here, as it may be wiped unexpectedly.



___

### `/boot` (Bootloader Files)

**Purpose**: Contains files required to boot the system, such as the Linux kernel, initial RAM disk (initrd), and bootloader configuration.

**Important Files**:

* `vmlinuz`: The Linux kernel binary.
* `initrd.img`: Initial RAM disk image used during boot.
* `grub`: Bootloader configuration files for GRUB (e.g., `/boot/grub/grub.cfg`).

**Caution**: Modifying or deleting files here can render the system unbootable.



___

### `/proc` (Processes Information)

**Purpose**: A virtual filesystem providing information about running processes and the system.

**Structure**:

* Each running process has a directory under `/proc`, named by its PID (e.g., `/proc/123` for PID 123).
* Includes system-wide information in files like `/proc/cpuinfo` (CPU details) and `/proc/meminfo` (memory usage).

**Usage**:

* Inspect a process's open files with `ls /proc/<PID>/fd`.
* Check system stats with `cat /proc/cpuinfo`.



___

### `/lost+found` (Recovered Files)

**Purpose**: Stores files recovered by filesystem checks (e.g., `fsck`) after an unexpected shutdown or crash.

**Usage**: May contain recovered files for inspection.



___

### `/srv` (Service [Served] Data)

**Purpose**: Contains data served by the system, such as web server files or FTP directories.

**Usage**:

* Used by administrators to organise data for specific services.

**Example**: `/srv/http` for web content served by an HTTP server.



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

    * **Runtime Isolation**: Containers (e.g., Docker containers) are isolated at the runtime level using virtualisation or sandboxing techniques. Programs in `Program Files` do not have this runtime isolation - they share the same OS processes, memory space, and kernel.
    * **Standardised Environment**: Containers include a standardised environment (e.g., specific OS versions or libraries). Applications in `Program Files` rely on the host OS environment and are not as portable.
    
    Applications in `Program Files` are deeply integrated with the host OS (e.g., through shared DLLs [dynamically linked libraries] in `System32`), whereas containers are typically isolated and can run independently of the host system's configuration.
