import pandas as pd

def AddtoXl(name,mail,age,dateofBirth,role):
    df = pd.read_excel('./datastore.xlsx')

    new_row = pd.DataFrame({'Name': [name], 
                            'Age': [age], 
                            'DaateOfBirth': [dateofBirth],
                            'mail':[mail],
                            'role':[role]})

    df = pd.concat([df, new_row], ignore_index=True)

    df.to_excel('./datastore.xlsx', index=False)

    print("New row appended and Excel file updated successfully.")
    print(df)