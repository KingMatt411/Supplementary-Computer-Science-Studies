# When Methods Return References

In Java (as well was many other languages, such as C#, Python, and JavaScript), **methods do not return objects directly, instead, they return references to objects**.

**That is, they return the memory address of where an object is stored.**

*Methods in some other languages, such as C++, Go, and Rust, return copies of objects directly by value. However, this document is designed to address the languages that return objects by reference.*

## Where Type Casting is Required

Both actual objects, and references to objects (i.e., variables), have types. While in C++ this is explicit (`std::string` and `std::string*` are both valid and different variable types), in Java (and similar languages), there is no explicit pointer/reference notation for variable types). The Java variable type `String` is actually the same as a C++ `std::string*` pointer under the hood.

Further obscuring the processes taking place under the hood is the fact that when the variable name is used in C++, it requires explicit dereferencing using the `*` operator on the variable name, while this happens implicitly in Java.

**\*It is important to remember that all Java variables (except primitive types) are references (essentially C++ pointer types). Therefore, they do have a specific type (equivalent to a C++ `std::string*`, `std::vector*`, `std::map*`, etc.), even if this type is not the same as the actual object that they point to.**

### Upcasting

Languages like Java allow a superclass reference **(that is, a variable)** to point to (hold the address of) a subclass object. This is called **upcasting**.

For example, you can assign the address of an `ArrayList` to a `List` variable. Similarly, an `HttpURLConnection` can hold the address of (point to) a `URLConnection`.

No casting is needed to assign the address of a subclass object to a superclass reference (variable).

#### Upcasting of References Returned by Methods

The concept of upcasting extends to the case of methods returning references:

* A method with a specified return type of `List` can return the memory address of an `ArrayList`.
* A method with a return type of `URLConnection` in its signature can return a reference to an `HttpURLConnection`.

While a method can only have a single return type (that being a reference variable), the reference it returns can point to any object of that class, or any of its subclasses.

This is demonstrated by the following method:

```java
public List<String> getListDescendant(boolean getArrayList) {
    if(getArrayList) {
        return new ArrayList<String>();
    } else {
        return new LinkedList<String>();
    }
}

List<String> listDescendant = getListDescendant(true);
```

#### Downcasting

**Downcasting** refers to assigning the address of a base (parent) class to a variable whose type is a reference to one of that class's child classes. Downcasting requires explicit casting of the reference being assigned to the child class variable (reference) it is being assigned to, or one of its child classes.

In the earlier upcasting example, the method returns an address of type `ArrayList<String>*` (obviously not a true pointer like in C++, but this is probably the only clear way of demonstrating this), which can be assigned to `List<String>*` due to upcasting, despite the address pointing to an object of type `ArrayList<String>`.

However, you cannot assign an address pointing to a parent class to a variable (reference) to one of its subclasses, even if the parent class reference points to an actual object of the subclass, without explicitly casting it as the subclass type.

For example, in the code below, `openConnection()` returns a reference of type `URLConnection` (or as would be clear in C++, `URLConnection*`), despite actually holding the address of (pointing to) an object of type `HttpURLConnection`. Due to this, even though the actual object pointed to by the reference being returned is of the type that the assignee variable points to, the reference to this object returned by the `openConnection()` method cannot be assigned to the variable of (theoretical) type `HttpURLConnection*`, unless it is cast as a reference to this type or one of its subclasses.

```java
URL url = new URL("https://api.example.com/data");

HttpURLConnection connection = (HttpURLConnection) url.openConnection();
```

Therefore, the reference returned by `url.openConnection()` is cast as a reference to an `HttpURLConnection` object so that it can be assigned to the `connection` (pointer) variable.
