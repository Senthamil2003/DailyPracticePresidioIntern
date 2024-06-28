
#Input Example
name=input("enter the name")
print("welcome "+ name)

#Data types in python
int_value=10
float_value=10.5
bool_vaue=10==10
string_value="Jhon"
range_value=range(10)

print(int_value,float_value,bool_vaue,string_value,range_value)

#List are Mutable
list_value=[1,2,3,4]
list_value.append(10)
print(list_value)
#'remove the element'
list_value.remove(1)
print(list_value)
#'pop delete last data and return it'
list_value.pop()
print(list_value)
#'del remove the element at the particular index'
del list_value[1]
print(list_value)

#'Tuples are Immutabl (no add remove)'
tuple_value=(1,2,3,4)
print("tuple with index",tuple_value[1])
new_tuple=(5,6,7)
tuple_value+=new_tuple
print("After concatination ",tuple_value)


#'unordered and o(1) accessing element'
set_value=set()
set_value.add(1)
set_value.add(2)
set_value.add(3)
set_value.add(4)

print(set_value)


