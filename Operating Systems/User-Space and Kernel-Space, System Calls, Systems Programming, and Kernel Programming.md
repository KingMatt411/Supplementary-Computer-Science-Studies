# User-Space and Kernel-Space, System Calls, Systems Programming, and Kernel Programming



## User-Space and Kernel-Space

The CPU can and does execute all types of CPU instructions. However, while some instructions can be executed directly by any application, other operations require the calling process to be running in kernel-mode.

**You may often read or hear something to the effect of *"user-space applications do not access hardware directly, this is done via system calls provided by the kernel"*.**

This is actually somewhat misleading, as user-space applications can and do control hardware directly, however this is limited to executing specific CPU instructions, such as arithmetic and logic operations, moving data between CPU registers, and managing control flow within the process. Instructions relating to hardware I/O operations, interrupts, memory protection, direct access to peripherals (like disk controllers or network interfaces) and CPU mode switching (user mode to kernel mode and vice versa) may only be executed in kernel-space, and if a user-space process requires the execution of these instructions, it must make a system call via the kernel's interface.

For example, if an application contains an instruction like `a + b`, this is executed directly by the CPU, without any intermediary (such as a kernel). However, if an application wants to write to a file on disk, it must do so by using a system call like `write()`, in response to which the kernel will execute the lower-level (kernel-space) instructions involved in actually writing the data directly to disk.

Many high-level programming languages, such as JavaScript, Python, C#, and Java, do not include any built-in instructions for executing kernel-space operations. **C**, on the other hand, is one of the few languages that includes the capability to write kernel-space code. This is why C is commonly used for kernel programming and device driver development. However, even though C contains the necessary syntax and functionality to write kernel-space instructions, when a program written in C runs in user-space, it is still subject to the same restrictions as any other user-space program. If the program tries to directly execute a kernel-space instruction, the operating system will prevent it, and an error will occur. The program must still rely on system calls to request the kernel to perform these privileged operations.

The following lists categorise several direct hardware instructions into those that can be executed by an application running in user-space, and those that require a system call to a kernel-space process:

#### Instructions Executed Directly from User-Space

* **Arithmetic Instructions**
* **Logic Instructions**
* **Data Movement Instructions**: Moving data between registers, memory, and stack.
* **Control Flow Instructions**: Branching and jumping within the user-mode code.
* **Bit Manipulation Instructions**: Modifying specific bits in a register or memory.
* **String Operations**: For working with strings and arrays.
* **Floating-Point Instructions**: Handling floating-point arithmetic.
* **SIMD (Single Instruction, Multiple Data) Instructions**: For parallel data processing, typically in multimedia applications.
* **No Operation**: The `NOP` instruction does nothing but consumes a CPU cycle.

Essentially, in user-space (when a user-space process is executing its own instructions directly), the CPU is limited to performing operations on data.

#### Instructions Requiring a Call to Kernel-Space

* **I/O Operations**: Directly reading from or writing to hardware ports.
* **Memory Management Instructions**: Managing virtual memory, page tables, and memory protection.
* **Interrupt Handling**: Enabling, disabling, or sending interrupts.
* **Context Switching Instructions**: Switching between tasks or processes.
* **CPU Control Instructions**: Controlling CPU state or mode (e.g., entering/exiting low-power states, mode switching).
* **System Call Instructions**: Invoking system calls to transition to kernel mode.

If you have not studied kernel programming, many of the kernel-space instructions may be unfamiliar. This highlights the fact that most of these types of instructions are abstracted by system calls.

#### Train and Train Network Analogy

An analogy for user-space and kernel-space is that of a train (representing user-space) operating within a larger train network infrastructure (representing kernel-space). The train network controls the routes a train can take (e.g., tracks, railroad switches, timetables), and the amount and timing of coal (representing system resources) provided. While the train can perform actions like starting and stopping, and opening and closing doors, it must always operate within the constraints of the train network - it cannot deviate from the tracks, or move without coal.

When the train moves, it interacts directly with its hardware (i.e., coal, tracks, engine, switches), but the configuration and scheduling of these elements are outside the train's control. This is analogous to how user-space processes interact with hardware but are limited by the kernel, which manages access to those resources.

This analogy illustrates how user-space processes have the freedom to execute tasks, but rely on kernel-space for managing resources and enforcing system limitations.

##### Systems Programming

Systems programming involves interacting with system resources, such as memory, files, and processes, through system calls. It involves the programmer engaging with the kernel at a low level, but not directly controlling hardware, as is done in kernel programming.

In this context, systems programming can be compared to the role of a train operator (not to be confused with a train network operator). The train operator has an interface in the cabin that allows them to send commands (system calls) to the central to the central rail system (the kernel), which ultimately controls the network.