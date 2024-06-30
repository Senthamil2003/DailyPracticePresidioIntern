#string manipulation in python
name="Captain America"

#Capitalize
print(name.capitalize())
#lower case
print(name.lower())

#find will thow weeor if substring not found
txt = "Hello, welcome to my world."

x = txt.index("welcome")

print("using index",x)

#index wont throw error is substring not found return -1
txt = "Hello, welcome to my world."

x = txt.find("sample")

print("using find",x)

#----------------------------function in python----------------------------

#void function
def greet(name):
    print("welcome "+name)

#fruitfull function 

def greetReturn(name):
    return "Welcome "+name

greet("Harry")
print(greetReturn("Harry"))



#Tuple are immutable can store duplicate
tuple_value=(1,2,3,4,1)
print("tuple with index",tuple_value[1])
new_tuple=(5,6,7)

#adding element to tuple
tuple_value+=new_tuple
print("After concatination ",tuple_value)

#unpacking Tuple

anime=("One Piece","Attack on Titans","Death Note")
(first,second,third)=anime
print(first,second,third)


#set in python
#unordered and o(1) accessing element
set_value=set()
set_value.add(1)
set_value.add(2)
set_value.add(3)
set_value.add(4)

print(set_value)
#remove element
set_value.remove(1)

#Dictionary o(1) access no duplicate key 
data = {
  "name": "Sam",
  "age": 12,
  "addresss": "Abs 123"
}
print(data["name"])





