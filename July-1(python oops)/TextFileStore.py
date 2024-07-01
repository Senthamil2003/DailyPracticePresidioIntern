def saveToTxt(name,mail,age,dateofBirth,role):
    text=""
    with open('./datastore.txt', 'r') as file:
        lines = file.readlines()
        if(len(lines)==0):
            text+="Name-Age-DaateOfBirth-mail-role\n"
    
    text+=f"{name}.{mail}.{age}.{dateofBirth}.{role}"
    with open('./datastore.txt', 'a') as file:
        file.write(text)
        file.write(f"Date of Birth: \n")
       
        file.write("\n")  # Add a newline for separation between records

