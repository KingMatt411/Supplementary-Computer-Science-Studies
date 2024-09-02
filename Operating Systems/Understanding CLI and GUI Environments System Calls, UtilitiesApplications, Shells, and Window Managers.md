# Understanding CLI and GUI Environments: System Calls, Utilities/Applications, Shells, and Window Managers

When you hear the terms command-line **interface** and graphical user **interface**, it is not obvious what exactly they are providing a (direct) interface to. That is, what specifically does a user use a CLI or GUI to interface with?

The best answer for now is **utilities/applications**.

*\*Note that the term "utilities" is typically used to describe CLI-based applications, while "applications" more commonly refers to GUI-based applications.*

The user does not interface directly with the kernel. In a CLI environment, system calls are made to the kernel by a **shell, and command-line utilities**. In a GUI environment, system calls are made to the kernel by a **window manager, and graphical applications**.

## CLI Environment

The CLI environment consists of the following key components:

### Terminal

In the early days of computing, the end point of a communication line that allowed users to interact with a computer (i.e., a teletype machine or video display unit) was known as a **terminal**.

> *\*A teletype machine (or "teleprinter") is an electromechanical device that can be used to send and receive typed messages through various communication channels (essentially the old-fashioned equivalent of a modern-day computer keyboard).*

These devices were located at the end of a communication line (like a serial connection to a mainframe), which was the reason for the name "terminal".

> *\*A **serial connection** is a method of data transmission where all the bits in a single byte (or word) are transmitted sequentially over a single channel. While multiple channels may be transmitting data simultaneously (e.g., in a Gigabit Ethernet twisted pair cable), all the bits making up a specific byte are handled entirely by a single channel. This contrasts to **parallel communication**, in which the bits making up a byte are split between different channels. Common uses of serial communication include USB (Universal Serial Bus) and Ethernet, while parallel communication is commonly used in high-speed, short-distance communication scenarios (such as communication between internal components within a computer like the CPU, RAM, and other peripherals).
>
> \*A **mainframe** is a powerful, large-scale computer primarily used by large organisations for critical applications, bulk data processing, and large-scale transaction processing.*

Therefore, a **terminal** is an physical hardware device (using old technology types) consisting of a keyboard and a screen, used to interact with a computer system. Traditional terminals are sometimes referred to as "dumb" terminals.

#### Difference Between Traditional Terminals and Modern Keyboards and Monitors

Modern keyboards and monitors interact with computers at a higher level of abstraction than traditional terminals. They use different protocols to traditional "dumb" terminals, and are predominantly intended for GUI interaction.

Due to the significant differences between the operation of traditional, "dumb" terminals and modern peripherals such as keyboards and monitors, in order to interact with CLI-based software designed to be controlled by a "dumb" terminal (such as shells and other CLI-based utilities), modern systems need to employ terminal emulators.

#### Terminal Emulators

A terminal emulator is a software application that replicates the functionalities of a traditional computer terminal within a graphical user interface. The primary purpose of a terminal emulator is to allow users to interact with the CLI-based utilities (i.e., shells and other utilities) of an operating system.

##### Examples of Common Terminal Emulators

- **Linux**: GNOME Terminal, Konsole, Xfce Terminal
- **macOS**: Terminal, iTerm2
- **Windows**: Windows Terminal (for PowerShell), Console Host (for CMD shell)



##### Why are Terminal Emulators Required for Modern Systems?

Even modern shells like `bash`, `zsh`, and others still require an environment that emulates the behaviour of old terminals. This is the case for several reasons:

* **Text-Based Interaction**: Even though we have moved to more graphical interfaces, shells are fundamentally text-based tools. They work best in an environment that can handle text input and output in a way that is consistent with the behaviour of old terminals. Terminal emulators provide this environment.

- **Compatibility with Existing Software**: Shells and many command-line utilities were originally designed to operate within the constraints and behaviours of physical terminals.
- **Standardised Interface**: Terminal emulators provide a standardised way for shells and text-based programs to interact with the user. They ensure that the commands typed into a shell are correctly interpreted and that the output from the shell or other CLI-based programs is displayed properly.

*The development of early terminal emulators was driven by the need to remotely access and interact with computers, especially in environments where mainframes or minicomputers were shared across multiple users or locations. This remote access capability laid the groundwork for more modern protocols like SSH and influenced the design and functionality of terminal emulators as essential tools for remote computing.*



### Shell

A shell text-based utility specifically designed to interpret and execute commands, playing a unique and central role in the CLI environment. When you launch a terminal emulator, it typically starts a shell process, which then interprets and executes your commands.

#### Text-Based Command Interpreter

When you enter a command in a shell, the shell parses that command and determines what actions need to be taken.

- **Internal Shell Command**: Internal shell commands (such as `cd` or `echo`) are handled directly by the shell itself.
- **System Calls via the Kernel**: For commands that involve interacting with the hardware or managing resources (like file operations), the shell makes system calls to the kernel. The kernel then directly interacts with the hardware or allocates resources as needed.
- **Executing External Programs**: Many commands are not built into the shell but are external programs or binaries (like `ls`, `grep`, or `python`). When the shell encounters such a command, it will:
  1. **Locate the Executable**: The shell searches for the executable file in the directories specified in the `PATH` environment variable.
  2. **Fork and Execute**: The shell uses the `fork` system call to create a new process. The child process then uses the `exec` family of system calls to replace its memory with the executable code of the command.
  3. **Wait and Return**: The shell will wait for the process to complete (foreground processes) or immediately return to the prompt (background processes).
- **Pipeline and Redirection**: The shell can also handle complex operations like piping the output of one process into another (e.g., `ls | grep txt`) or redirecting input/output to files or devices. This involves creating multiple processes and managing their input/output streams.

#### Rules and Semantics for Interactions

Each shell has its own syntax, built-in commands, and scripting capabilities, which define how users interact with the kernel. The specific rules and semantics of a shell distinguish different types of shells from one another. Some common shells include:

- **Bash** (Bourne Again Shell) is commonly used on Unix-like systems, including those running the Linux kernel. It can also run on systems using the XNU kernel (macOS). Bash was the default shell on macOS until macOS Catalina (10.15), when Zsh became the default.
- **Zsh** is another Unix-like shell that can be used on both systems with the Linux kernel and systems with the XNU kernel (such as macOS). Zsh is currently the default shell on macOS.
- **PowerShell** is designed for use with the Windows NT kernel.
- **PowerShell Core** is a cross-platform version of PowerShell built on .NET Core. It can run on the Windows NT, Linux, and XNU kernels, making it more versatile for environments that involve multiple operating systems.

#### Other Capabilities of Shells

Some other common functions of a shell include:

* **Scripting and Automation**: It enables the creation and execution of scripts to automate repetitive tasks.
* **Process Control**: Manages the execution of programs, including launching, stopping, and backgrounding processes.
* **Environment Management**: Sets and retrieves environment variables that configure the behaviour of the operating system and applications.

**The same kernel can be controlled by different shells. For example, Bash, Zsh, Ksh, Fish, Csh, Tcsh, Dash, and Ash can all be used to control Unix-like kernels.*



### Utilities (Applications)

Utilities are command-line programs or tools that perform specific tasks. They are essentially the command-line version of what we normally think of as applications (such as web browsers, text editors, IDEs, games, etc.).

CLI-based utilities range from simple commands (like `ls`, and `cp`) to more complex utilities like text editors (e.g., `vim`, `nano`) or network tools (e.g., `ping`, `curl`). Utilities can be built into the shell or installed separately.

*Some examples of more complex or large-scale CLI utilities that perform advanced, multi-step or resource-intensive tasks include `git`, `ffmpeg` (a multimedia processing tool), `docker`, and `kubectl` (command-line Kubernetes tool).



## GUI Environment

A GUI environment consists of the following key components:

### Window Manager





### Graphical Applications





### Desktop Environment (Optional)





It may be helpful (and more accurate) to let go of the idea of a command-line interface and a graphical user interface as things (or nouns), and replace this with the idea of command-line interfac**ing** and graphical interfac**ing** (verbs). The reason for this is explained below:

>*The most common scenario in modern times is for a shell (CLI-based process) to run within a (graphical) terminal emulator (GUI-based process) within a window manager (GUI-based process). In this scenario, what exactly is the command-line interface? You might want to say that it is the shell, but a shell itself is not an interface. What would it be an interface of? It is not a direct interface of the kernel. The kernel has its own interface of system calls, and the shell accesses this interface, but the shell itself is not this interface. The most correct answer would probably be the terminal emulator (or physical terminal, if you were using an early-days computer). However, ChatGPT 4o stated that a (physical) terminal is "not a command-line interface, but [it] provides the physical means to access a CLI." If neither the terminal nor the shell is actually the elusive CLI, then what is?*

When you are actively using (interacting with) a shell, or command-line utility, you are command-line interfacing. Similarly, when you are using (interacting with) a graphical application, you are graphically interfacing. What you are interfacing with specifically may always be somewhat of an abstract concept. Nonetheless, it would be hard to go wrong as long as you understand that the components of a CLI environment are a shell and command-line utilities, while the components of a GUI environment are a window manager, graphical applications, and (optionally) a desktop interface.

Finally, as demonstrated in the last sentence of the previous paragraph, you could also think of CLI and GUI as adjectives, which can be used to describe individual utilities/applications, or environments. A CLI environment facilitates text-based interaction. It consists of components like a shell, terminal emulator, and system libraries. A GUI environment facilitates graphical interfacing. `top` is a CLI utility. Brave Browser is a GUI application.