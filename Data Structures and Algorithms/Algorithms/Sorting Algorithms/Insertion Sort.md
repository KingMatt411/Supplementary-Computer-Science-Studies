# Insertion Sort

### Concept

Insertion Sort is a comparison-based sorting algorithm that works similarly to how you might sort playing cards in your hand.

1. Start with the first element (consider it sorted).
2. Pick the next element and insert it into its correct position in the **sorted portion** of the array.
3. Repeat for all remaining elements.

___

### How It Works

1. Divide the array into two parts:
   * **Sorted portion** (initially just the first element).
   * **Unsorted portion**.
2. Pick the first element from the unsorted portion.
3. Shift elements in the sorted portion to make space for the picked element if needed.
4. Insert the picked element into its correct position in the sorted portion.
5. Repeat until the entire array is sorted.