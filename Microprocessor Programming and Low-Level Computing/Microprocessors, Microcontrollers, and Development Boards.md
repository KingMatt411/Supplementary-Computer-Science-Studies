# Microprocessors, Microcontrollers, and Development Boards

### Microprocessor (CPU)

A microprocessor (CPU) is an **integrated circuit (IC)**, designed to execute instructions and perform computations.

An integrated circuit (IC) is a small, flat chip made of semiconductor material (usually silicon) that integrates multiple electronic components into a single device. These components can include:

* **Transistors**: Switches that control the flow of electricity.
* **Diodes**: Components that allow current to flow in one direction.
* **Resistors**: Components that limit or control current.
* **Capacitors**: Components that store and release electrical energy.

A microprocessor is **purely a processing unit (without memory or peripherals)**. It is designed for general-purpose computing tasks.



### Microcontroller (MCU)

A microcontroller is a compact **system-on-a-chip (SoC)** used in embedded systems, and designed for specific control applications. It includes:

1. **Microprocessor (CPU)**: Executes instructions.
2. **RAM**: Temporary storage for variables and data during program execution.
3. **Flash Memory**: Non-volatile storage for program code.
4. **Peripherals**: Hardware modules like ADCs, timers, GPIO, UART, I2C, SPI, etc., used to interact with the external world.

Most smaller electronics and embedded systems use microcontrollers (system-on-chips), as the high level of component integration minimises size, power consumption, and cost, which are crucial in embedded systems. Physical separation of components is more so a characteristic of general-purpose computers (like desktops, laptops, and servers).

***Microcontrollers are a subset of SoCs that are intended for embedded systems. Apple Silicon chips are SoCs with a more advanced and general purpose, not aimed specifically at embedded systems. Therefore, they are not considered microcontrollers.***

#### ATtiny1626

The ATtiny1626 is a microcontroller from the ATtiny microcontroller family from Microchip Technology. It uses the AVR architecture.

The following are the core features of the ATtiny1626:

* **Architecture: 8-Bit**

  * CPU processes 8 bits of data at a time.

    * The Arithmetic Logic Unit (ALU) is designed to perform operations on 8-bit data.
    * Registers in the CPU are 8 bits wide.
    * Data stored in SRAM or passed between peripherals is generally handled in 8-bit chunks.

    While the CPU processes 8 bits at a time, it can work with larger data by combining multiple 8-bit operations.

* **16-Bit Instruction Set**

  * In AVR microcontrollers, each machine instruction is 16 bits wide.
  * A single instruction can encode more information, such as which registers to use, the operation to perform, and immediate values.
  * A wider instruction set allows for denser encoding of operations. For example, one 16-bit instruction can specify an operation and operands, reducing the number of cycles needed to perform common tasks. Some microcontrollers with 8-bit instruction sets require multiple instructions to perform the same task that an AVR can do with one 16-bit instruction.

* **Flash Memory**: 16 KB of in-system programmable flash memory.

* **SRAM**: 2 KB (see notes on SRAM below)

* **EEPROM**: 256 bytes, suitable for non-volatile data storage

* **Operating Voltage**: 1.8V to 5.5V, making it suitable for battery-powered and low-power designs.

* **Operating Frequency**: Up to 20 MHz.



##### Dynamic RAM (DRAM) vs. Static RAM (SRAM)

**Dynamic RAM (DRAM)** is widely used in devices like desktop computers, laptops, and mobile phones as main system memory (RAM). This is due to the following features:

* **High Capacity**: DRAM cells are smaller (1 transistor + 1 capacitor per bit), allowing higher memory density.
* **Cost-Effectiveness**: DRAM is cheaper to produce compared to SRAM, making it suitable for large-capacity requirements.

**Static RAM (SRAM)** is commonly used in embedded systems, microcontrollers, and other applications requiring high-speed memory. Its key characteristics include:

* **Speed**: SRAM is faster than DRAM.
* **Applications**: Commonly used for CPU caches, peripheral buffers, and volatile memory in embedded systems, where fast temporary storage is critical.



### Development Board

A development board is a hardware platform built around a microcontroller or microprocessor to make development easier. It typically includes the following components:

1. **Microcontroller/Processor**: The central component (e.g., ATtiny1626).
2. **Support Components**: Voltage regulators, clock sources, and interfaces for programming and debugging.
3. **User Accessible I/O**: Breakout pins, buttons, LEDs, displays, or sensors.
4. **Connectivity**: Interfaces like USB, UART, or Wi-Fi for communication with a computer or other devices.

A development provides a user-friendly platform for programming, prototyping, and testing applications with a microcontroller or microprocessor. It includes essential hardware components (e.g., power supply, I/O connectors, interfaces) to simplify interaction with the core chip, making it easier to focus on software and system development without building circuits from scratch.





















