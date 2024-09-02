# Setting Up and Installing VMware Workstation Pro on Ubuntu

### Downloading and Installing VMware Workstation

1. Download the `.bundle` package from the Broadcom website and run it using:

    `sudo ./VMware-Workstation-Full-<version>.x.bundle`

2. Open the VMware application and follow the prompts to build the necessary modules.

    ***Depending on your version of Ubuntu, you may encounter an error stating that the `vmmon` and `vmnet` modules were unable to be built. To resolve this, a patch has been created and is being actively managed. This is available here:***

    [vmware-host-modules](https://github.com/mkubecek/vmware-host-modules)

1. Clone the repository and checkout to the branch corresponding to your version of VMware Workstation. At the time of writing this, the most recent version is *17.5.1*.

2. To build the necessary modules, you can follow the instructions in the `INSTALL` file.

3. The instructions state to run the following commands **while the current working directory is the Git repository**:
   
    ```
    sudo make
    sudo make install
    ```
4. After doing this, you should be able to run VMware Workstation successfully.

### Signing the VMware Modules and Enrolling the Key with Secure Boo

Since VMware Workstation Pro does not currently ship `vmmon.ko` and `vmnet.ko` in the bundle, and these kernel modules (drivers) are built (compiled) locally during installation of the software, they are not signed by a key trusted by the Secure Boot environment. On a Linux host with Secure Boot enabled, the kernel will not load these unsigned drivers. Therefore, in order to run these drivers (which is necessary to power on virtual machines in VMware), you need to generating a key pair using `openssl` to use to sign the modules, sign the modules using the generated key, and import the public key to the system's MOK list.

There is a helpful article provided by Broadcom that explains how to do this. It can be accessed here:

[Cannot open /dev/vmmon: No such file or directory" error when powering on a VM
](https://knowledge.broadcom.com/external/article/315309/cannot-open-devvmmon-no-such-file-or-dir.html)