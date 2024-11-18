# Logical Operations

### What Are Logical Operations?

Logical operations are used for manipulating binary data. They operate on **binary inputs (0 or 1)**, often representing values of **false** and **true**. Some common logical operations include `AND`, `OR`, `NOT`, and `XOR`.

#### Bitwise Operations

The term **bitwise** refers to logical operations applied directly to the binary representation of numerical data, manipulating individual bits (or pairs of bits). While *conceptually* distinct from regular logical operations on Boolean values, at the circuitry level, the data being operated on are exactly the same (simply high and low voltages), and the CPU does not differentiate between whether it is being used for a numerical or Boolean purpose.



___

### Logical Operations and Truth Tables

**Truth tables** summarise how logical operations behave for all input combinations. Below are truth tables for several common logical operations:

#### `AND` Function

* **Definition**: Outputs 1 only of both inputs are 1.

* **Truth Table**:

  | A    | B    | A AND B |
  | ---- | ---- | ------- |
  | 0    | 0    | 0       |
  | 0    | 1    | 0       |
  | 1    | 0    | 0       |
  | 1    | 1    | 1       |

* **Bitwise AND Example**:

  ```
  a: 0011101001101001  
  b: 0101100100100001  
  c: 0001100000100001
  ```

#### `OR` Function

* **Definition**: Outputs 1 if at least one input is 1.

* **Truth Table**:

  | A    | B    | A OR B |
  | ---- | ---- | ------ |
  | 0    | 0    | 0      |
  | 0    | 1    | 1      |
  | 1    | 0    | 1      |
  | 1    | 1    | 1      |

* **Bitwise OR Example**:

  ```
  a: 0011101001101001  
  b: 0101100100100001  
  c: 0111101101101001
  ```

#### `NOT` Function

* **Definition**: Inverts the input (0→1, 1→0).

* **Truth Table**:

  | A    | NOT A |
  | ---- | ----- |
  | 0    | 1     |
  | 1    | 0     |

* **Bitwise NOT Example**:

  ```
  a: 0011101001101001  
  c: 1100010110010110
  ```



#### `XOR` Function

* **Definition**: Outputs 1 if inputs differ, otherwise outputs 0.

* **Truth Table**:

  | A    | B    | A XOR B |
  | ---- | ---- | ------- |
  | 0    | 0    | 0       |
  | 0    | 1    | 1       |
  | 1    | 0    | 1       |
  | 1    | 1    | 0       |

* **Bitwise XOR Example**:

  ```
  a: 0011101001101001  
  b: 0101100100100001  
  c: 0110001101001000
  ```

___

### DeMorgan's Laws (Logical Equivalences)

DeMorgan's Laws are **logical equivalences** that describe the relationships between the AND, OR, and NOT operations. These laws allow you to transform complex logical expressions into simpler or alternative forms.

1. **NOT(A AND B) == NOT(A) OR NOT(B)**

   * **Code Representation**:

     `!(A && B) == !A || !B`

   * **Meaning**: The negation of an AND operation is equivalent to the OR of the negations of the operands.

   * **Example**:

     If A == 1 and B == 0:

     * A AND B == 0
     * NOT(A AND B) == 1
     * NOT(A) OR NOT(B) == 1

2. **NOT(A OR B) == NOT(A) AND NOT(B)**

   * **Code Representation**:

     `!(A || B) == !A && !B`

   * **Meaning**: The negation of an OR operation is equivalent to the AND of the negations of the operands.

   * **Example**:

     If A == 0 and B == 1

     * A OR B == 1
     * NOT(A OR B) == 0
     * NOT(A) AND NOT(B) == 0

___

### Bit Vectors and Masks

##### Bit Vector

A **bit vector** is a sequence of binary values where each bit represents a property or state. Each bit operates independently of the others, allowing compact representation of multiple properties.

For example, an 8-bit vector `11000010` could represent the status of 8 machines:

* 1 = free/available
* 0 = busy/unavailable

Here, machines 7, 6, and 1 are free.

##### Bit Mask

* A **bit mask** is a binary pattern used to isolate, modify, or check specific bits in a bit vector.

* **This is done by combining a bit mask with a bit vector using bitwise operations (like AND, OR, and NOT).**

* Masks focus on relevant bits (set to 1) while ignoring others (set to 0).

##### Common Operations with Bit Vectors and Masks

1. **Isolation (AND)**

   * Retains only the relevant bits from the vector by masking out the others (set to 0).

   * Example:

     ```ruby
     A:      01010110  (bit vector)
     Mask:   00000011  (mask to isolate rightmost 2 bits)
     Result: 00000010  (only bits 1 and 0 are kept)
     ```

2. **Setting Specific Bits (OR)**

   * Sets specific bits in the vector to 1 without altering other bits.

   * Example:

     ```ruby
     A:      01000010  (bit vector)
     Mask:   00100000  (mask to set bit 5)
     Result: 01100010  (bit 5 is now set to 1)
     ```