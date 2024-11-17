# Data Types

### Signed Integers (2's Complement)

2's complement is a method of representing signed integers in binary. It refers to both the **representation** (how numbers are stored) and the **operation** (how to calculate the negative of a number in binary).

* **Positive Numbers**: For signed integer data types, positive integers are represented as they are in unsigned binary (e.g., `5` in a 4-bit system: `0101`).

* **Negative Numbers**: Negative numbers are represented by flipping the bits of the positive number and adding `1` to the least significant bit (LSB). For example:

  * **`-5` in a 4-bit system:**

    1. Write `5` in binary: `0101`.
    2. Flip the bits: `1010`.
    3. Add `1`: `1010 + 1 = 1011`.

    *The most significant bit (MSB) is reserved as the sign bit, where `0` represents positive, and `1` represents negative. Therefore, in a 4-bit signed integer, the minimum and maximum values that can be represented are `-8` (`1000`) and `7` (`0111`) respectively.*

    > Flipping the bits in 2's complement creates the binary "one's complement", and adding 1 ensures the correct negative equivalent by making the sum of a positive number and its 2's complement equal zero in binary arithmetic. This enables the CPU to seamlessly perform addition and subtraction.
    >
    > * If you actually try this, you will notice that it doesn't technically equal zero, however the carried 1 is discarded due to falling outside the number of bits (thus making the result zero).
    
$$
\begin{matrix}
    & _1 & _1 & _1 & \\
    & 0 & 1 & 1 & 1 \\
    + & 1 & 0 & 0 & 1 \\
    \hline
    1 & 0 & 0 & 0 & 0
\end{matrix}
$$

For representing negative signed integers, 2's complement is considered the industry standard and is used in almost all modern processors.

### How the CPU Treats Binary Values of Different Data Types

The CPU neither knows nor cares (if it were sentient) what a binary value's "data type" is. Data types (like `int` or `uint` are higher-level programming constructs). At the hardware level, the CPU processes binary bits **based on the rules of the specified operation (opcodes)**, such as signed integer arithmetic or floating point addition.

* An opcode may tell the CPU to treat a value as an integer and perform addition (`ADD R1, R2`).
* Another opcode may tell the CPU to treat the same value as a floating-point number and perform floating point addition.

The CPU does not inherently differentiate between data types - it merely follows the instructions provided by the opcode.

The following tables of opcodes demonstrates how different opcodes instruct the CPU to handle binary data in different ways:

##### Signed and Unsigned Integer Operations

| Opcode | Description                       |
| ------ | --------------------------------- |
| `ADD`  | Adds two signed integers.         |
| `ADDU` | Adds two unsigned integers.       |
| `SUB`  | Subtracts two signed integers.    |
| `SUBU` | Subtracts two unsigned integers.  |
| `MUL`  | Multiplies two signed integers.   |
| `MULU` | Multiplies two unsigned integers. |
| `DIV`  | Divides two signed integers.      |
| `DIVU` | Divides two unsigned integers.    |
| `CMP`  | Compares two signed integers.     |
| `CMPU` | Compares two unsigned integers.   |

##### Floating-Point Operations

*Floating-point numbers are inherently signed, there are no unsigned floating-point numbers in the IEEE 754 standard*.

| Opcode   | Description |
| -------- | ----------- |
| `FADD`   |             |
| `FSUB`   |             |
| `FMUL`   |             |
| `FDIV`   |             |
| `FCMP`   |             |
| `FSQRT`  |             |
| `FABS`   |             |
| `FNEG`   |             |
| `FROUND` |             |

##### Data Conversion Operations

| Opcode | Description |
| ------ | ----------- |
|        |             |

















