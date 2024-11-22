# Linux and macOS Filesystems

## Linux

### Root Directory (`/`)

The **root directory** (`/`) is the **top-level directory** in the Linux filesystem hierarchy and serves as the starting point for all other directories and files on the system. It is the **root** of the directory tree, from which all other directories branch.

#### Key Characteristics of `/`

1. **Top of the Filesystem Tree**
   * Everything in Linux is organised under `/`. Unlike Windows, which uses multiple drive letters (e.g., `C:`, `D:` for external drives or partitions), Linux mounts all filesystems, including additional drives, under the single root directory.
2. **Access Point for All Mounted Filesystems**
   * External storage devices (e.g., USB drives, additional hard disks, or network drives) are mounted to subdirectories under `/`, (e.g., `/mnt`, `/media`), or custom directories like `/data`