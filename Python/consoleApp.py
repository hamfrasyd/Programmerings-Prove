import requests

URL = 'http://localhost:5087/api/windows'

def GetAll():
    response = requests.get(URL)
    data = response.json()
    return data, response

windowsList, getAllResponse = GetAll()

if getAllResponse.status_code == 204:
    print("Listen er tom.")
elif getAllResponse.status_code == 200:
    for window in windowsList:
        print(f"ID: {window['id']} - Model: {window['model']} - EnergyClass: {window['energyClass']} - Price: {window['price']}")
else:
    print(f"Fejl ved hentning af Widnows: Status kode: {getAllResponse.status_code}, Reason: {getAllResponse.reason}")
    print(getAllResponse.text)