# Instruction Set Architectures (ISAs)

The Instruction Set Architecture (ISA) of a microprocessor (aka. processor, CPU) is the complete specification of the interface between a program and the computer hardware that executes it.

To draw an analogy with a car, the car's instruction set architecture (ISA) is the specification of everything that the human driver needs to know (e.g., what pressing the accelerator and brake pedals will do), and everything the car needs to do in response to this (e.g., the internal mechanics involved in accelerating or decelerating the car).

### Components of an ISA

The components of an ISA include the following:

#### 1. Opcodes and Operands

In assembly language or machine code, an instruction is divided into two parts: the opcode and the operand(s).

* **Opcode**: An opcode (short for *operation code*) is the portion of a machine language instruction that specifies the specific operation to be performed. Examples include `ADD` (for addition), `SUB` (for subtraction), `MOV` (to move data), etc.

* **Operands**: These are the values or addresses that the opcode will operate on, such as registers or memory locations.

For example, in the assembly instruction `ADD R1, R2`, the `ADD` part is the opcode, which instructs the CPU to add values, while `R1` and `R2` are operands specifying where to get the values.

***Note: Opcodes vary between different CPU architectures, as each processor family has its own instruction set, meaning a unique set of opcodes and associated operations***.

#### 2. Data Types

These are the types of data that the processor can operate on, such as integers, floating-point numbers, characters, and pointers. Each data type has specific bit lengths (e.g., 8-bit, 16-bit, 32-bit, 64-bit) and is crucial for determining how the CPU interprets binary data.

Some ISAs support complex data types like vectors or packed data types (where multiple values are held in a single register or memory location).

#### 3. Addressing Modes

Addressing modes define how an instruction should interact with its operands.

The ISA of a CPU specifies all the addressing modes it supports. Each instruction specifies (implicitly or explicitly) the addressing mode to be used for executing that particular instruction.

There are three main types of addressing modes, with the latter two having multiple subtypes.

* **Immediate Addressing**: The operand is treated as a **literal value**.
* **Direct Addressing**: The operand is treated as a **memory (RAM) address**.
* **Register Addressing**: The operand is treated as a reference to a specific **CPU register**.

#### *Variations Across ISAs*

The number of different opcodes, data types, and addressing modes differs across different CPU ISAs. Below is a table of some of the most common ISAs and the number of opcodes, data types, and addressing modes they support.

| Architecture | Opcodes | Data Types | Addressing Modes |
| ------------ | ------- | ---------- | ---------------- |
| **x86**      | 1,500+  | ~4         | ~12              |
| **ARM**      | ~100    | ~3         | ~6               |
| **MIPS**     | ~200    | ~2         | ~5               |
| **RISC-V**   | 50-100  | ~3         | ~4               |
| **AVR**      | ~130    | ~2         | ~6               |

___

#### Memory Specifications

The ISA specifies the number of unique memory locations the CPU can address, which is effectively the size of the **address space**. For example, a 32-bit ISA can theoretically address up to $2^{32}$ memory locations, or 4 GB of memory, while a 64-bit ISA can address up to $2^{64}$ locations. Since this addressing is **logical**, the same physical RAM can be used across different CPU architectures, as logical addresses are mapped to physical addresses by the CPU's memory management unit (MMU), making the physical memory architecture-agnostic.



#### Memory Words

A **memory word** is a fixed-size unit of data that a computer processor can read from or write to memory in a single operation. The size of a memory word depends on the architecture of the computer, and directly impacts how data is organised, stored, and accessed in memory.

##### Key Points About Memory Words

1. **Word Size**:
   * The **word size** (or **word length**) is typically measured in bits and often matches the **CPU's register size**. For example, in a 32-bit system, a word is usually 32 bits (4 bytes), and in a 64-bit system, a word is usually 64 bits (8 bytes).
   * The word size determines how much data the CPU can process at once, affecting the system's speed and performance.
   * Word size is defined by the **ISA of the CPU**.
2. **Memory Organisation**:
   * Memory is organised into words, and each word has a unique address.
   * When a CPU accesses memory, it typically reads or writes and entire word at once (though it may address smaller units such as bytes within that word).

##### Why Memory Word Size Matters

* **Performance**: Larger word sizes allow a CPU to process more data in a single operation, improving overall performance for data-intensive tasks.
* **Memory Efficiency**: Word size affects how data is packed in memory. For example, a 64-bit word allows storing larger numbers or more complex data types without splitting the data across multiple memory locations.

##### Summary Table

| System Type | Typical Word Size | Common Data Types Handled in One Word                      |
| ----------- | ----------------- | ---------------------------------------------------------- |
| 32-bit      | 32 bits (4 bytes) | 32-bit integers, single-precision floats, 32-bit addresses |
| 64-bit      | 64 bits (8 bytes) | 64-bit integers, double-precision floats, 64-bit addresses |

##### Processing of Words and Efficiency

A CPU processes an entire word at once, even if the data being processed is smaller than the word size. If a piece of data is smaller than the word size, leading zeros are applied as padding. It may seem inefficient to add, say, 63 leading zeros to represent the integer 1 in a 64-bit system. However, this trade-off helps maintain speed and simplicity due to the following reasons:

* **Memory Alignment**: CPUs are optimised to handle fixed-size data chunks that match their word size. Accessing aligned 64-bit chunks is much faster and simpler for the CPU hardware than trying to dynamically adapt to varying data sizes.
* **Consistency**: A consistent word size means that all instructions and memory accesses follow the same format, making the CPU's **control logic simpler and faster**.
* **Standard Data Types**: In most programming languages, variables are stored in standard data types (e.g., `int`, `float`, `char`) that align with word boundaries. This alignment allows the CPU to handle each data type predictably without needing to interpret varying sizes or add extra bitwise operations.
* **Memory Addressing and Pointers**: Memory addresses and pointers are also typically aligned to the word size as well. This alignment makes it easier for the CPU to address memory consistently, even if the data is smaller than a word.

While padding with zeros for a single bit like `1` may seem inefficient, the trade-off enables **massive speed and efficiency gains** across most typical operations. The benefit of aligning data with the CPU's word size greatly outweighs the minor inefficiency of padding for smaller data values.























