# PlatformIO Platforms

In PlatformIO, a **platform** provides all the essential tools, configurations and support necessary to develop and deploy software for a specific type of hardware. Specifically, a platform contains:

1. **Toolchain**: The tools required to compile, link, and upload code to the specific microcontroller.
2. **Frameworks**: Support for frameworks or development styles, such as:
   * Bare-metal programming (writing directly to registers without an operating system)
   * Assembly programming
3. **Board Definitions**: Metadata and configurations specific to the development board, such as pin mappings, clock settings, and memory sizes.
4. **Build System Integration**: Integrates with the PlatformIO build system, automating tasks like compiling, linking, and uploading firmware to the QUTy board.



## QUTy Platform

The QUTy platform enables students and developers to:

1. **Develop Firmware**:
   * Supports writing programs in C, Assembly, or bare-metal configurations for the QUTy board.
2. **Simplify Toolchain Setup**:
   * Automates the process of setting up the AVR GCC toolchain, including cross-compilation for the ATtiny1626 microcontroller.
3. **Abstract Complexity**:
   * Provides configuration files and scripts (e.g., `platformio.ini`) that handle complex build steps.
4. **Simulate Real-World Embedded Programming**:
   * Includes examples that simulate common embedded programming tasks like LED blinking, serial communication, and more.
5. **Manage Dependencies**:
   * Includes a board definition (`QUTy.json`) and build scripts that allow PlatformIO to recognise and work with the QUTy board seamlessly.



### Platform Structure

```
mattpatchava@mattpatchava-MS-7D77:~/.platformio/platforms$ tree
.
└── quty
    ├── boards
    │   └── QUTy.json
    ├── builder
    │   ├── frameworks
    │   │   └── _bare.py
    │   └── main.py
    ├── examples
    │   ├── quty_blinky_asm
    │   ├── quty_blinky_asm_bare
    │   ├── quty_blinky_c
    │   └── quty_serial_helloworld
    ├── LICENSE
    ├── platform.json
    ├── platform.py
    ├── __pycache__
    │   └── platform.cpython-312.pyc
    └── README.md

10 directories, 8 files
```

##### boards/QUTy.json

Defines the QUTy board's metadata:

* Pin mappings
* Microcontroller specifications (e.g., flash size, SRAM)
* Communication interfaces (e.g., UART, UPDI)

##### builder/

Contains Python scripts for building firmware:

* `frameworks/_bare.py`: A script for handling bare-metal framework builds.
* `main.py`: The main build script that directs how firmware is compiled and linked.

##### examples/

Pre-configured projects to demonstrate typical use cases:

* **quty_blinky_c**: Blinks an LED using C.
* **quty_blinky_asm**: Blinks an LED using Assembly with startup code.
* **quty_serial_helloworld**: Implements a basic serial communication example in C.

Each example includes:

* `platform.ini`: The configuration file for the example.
* `src/`: Contains the source code (C or Assembly).

##### platform.json

A critical configuration file for the platform, specifying:

* The platform name (`quty`)
* Tool dependencies (e.g., AVR GCC toolchain)
* Compatible frameworks (e.g., bare-metal)
* Supported boards (e.g., QUTy)