# Microarchitecture

Microarchitecture is the specific, internal design of a processor that determines how it executes instructions defined by an ISA (Instruction Set Architecture). It includes the low-level details of how the processor's components - such as arithmetic logic units (ALUs), registers, pipelines, and control units - are organised and how they work together to process instructions.

A processor's microarchitecture determines *how* a processor is built to execute commands, focusing on achieving a balance of performance, efficiency, and cost. Two processors may have the same ISA and therefore understand the same instructions, but their microarchitectures can differ greatly, leading to differences in speed, power usage, and overall capabilities.

#### Car Analogy

Building on the car analogy that was used to describe instruction set architectures (ISAs), the following explanations differentiate the nature of an ISA from a microarchitecture:

* **Car ISA**: Represents what the driver needs to know to operate the car. Regardless of the car brand, the essentials remain the same - the middle pedal is always the brake (for manual transmission cars, or ISAs), and the right pedal is the accelerator. This consistency means that you don't need different "licenses" for different car brands.
* **Car Microarchitecture**: Refers to the inner workings beneath the hood, where design choices affect cost and performance. Each car model varies.
  * Brake types may be disc or drum.
  * Engine types vary from four to twelve cylinders, and some may include turbocharging.
  * Fuel efficiency and price range widely.

#### Compatibility of Machine Code Depends on ISA, While Performance Depends on Microarchitecture

Code compiled for a specific ISA can generally run across all processors that support that ISA without recompilation, because the ISA is standardised across those models. This is why both an \$99 Intel Core i3 CPU with 4 cores and 8 threads can execute exactly the same instructions (opcodes), and therefore run exactly the same software without any compatibility issues as an \$8,000 AMD Threadripper CPU with 64 cores and 128 threads. However, the Threadripper would execute this instructions drastically faster, leading to a huge performance difference. Similarly, a Bugatti and a Prius can both drive around the same racetrack, and arguably both have the same ISA (accelerator and brake pedal), but vastly different internals (high-performance, turbocharged combustion engine vs. eco-friendly electric motor), but the Bugatti will do so drastically faster.

* Code compiled for an x86_64 ISA will run on any processor that uses this ISA, but the speed of execution (i.e., performance) will depend on the processor's microarchitecture.
* The same goes for ARM ISAs, however, while there is just one version of the x86_64 ISA, there are multiple versions of the ARM ISA, such as ARMv8 (used in Apple Silicon CPUs), ARMv7, ARMv6, etc.