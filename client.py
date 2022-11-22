import requests
import json
import time

from contextlib import contextmanager
import sys, os



class Client():

    def __init__(self):
        self.api_url = "https://localhost:"
        self.data = {}
        self.headers : str={
            'Content-type':'application/json', 
            'Accept':'application/json',
            'XApiKey':'kommst_du_net_rein'}     # sending the API-key to the controller
        self.api_ID = "noch leer"

    def exit_check(self, api_return):
        if api_return.status_code == 200:
            return
        sys.exit(f'\n{api_return.json()}, das Programm wurde beendet\n')

    def counting(self, n:int):
        while n > 0:
            print(n, end='\r')
            time.sleep(1)
            n -= 1
        print(" ", end='\r')
        return
        


    def buchung(self):
        print(f'\nBuchungsprogramm gestartet')
        port = input("Bitte localhost-port eingeben: ")
        self.api_url = self.api_url + port
        api_connector = self.api_url + "/Buchungsanfrage" 
        print(f'\nBuchungsanfrage gestartet\nIhr Taxi wird gebucht in...\n')
        
        self.counting(5)
       
        print(f'Ihr Buchung auf {api_connector} wird nun durchgeführt')
        response = requests.post(api_connector, verify = False, headers = self.headers, json = self.data)
        
        self.exit_check(response)
        self.api_ID = response.json()
        print(f'Ihr Taxi wurde gebucht, Ihre Kennung ist die {self.api_ID}')

        self.counting(3)


    def einsteigen(self):
        api_connector = self.api_url + "/einsteigen"
        print(f'\nIhr Taxi ist angekommen, Sie dürfen nun einsteigen\n')
        
        self.counting(5)

        response = requests.post(api_connector, verify = False, headers = self.headers, json = self.data)
        
        self.exit_check(response)

        print(response.json())
        
        self.counting(3)


    def aussteigen(self):
        api_connector = self.api_url + "/aussteigen"
        print(f'\nSie sind an Ihrem Ziel angekommen, Sie dürfen nun aussteigen\n')
        
        self.counting(5)

        response = requests.put(api_connector, verify = False, headers = self.headers, json = self.data)
        
        self.exit_check(response)

        print(response.json())
        
        self.counting(3)




    def bewerten(self):
        api_connector = self.api_url + "/rate_me"
        print(f'\nSie dürfen nun die Fahrt bewerten\n')
        stars = input("Bitte geben Sie eine Sternebewertung zwischen 1 und 5 ab: ")
        comment = input("Hier dürfen Sie freien Text für Ihre Bewertung eingeben")
        print("Ihre Angaben werden bearbeitet, bitte warten")

        bewertung_data = {
            "customer_ID": self.api_ID,
            "rating_stars": stars,
            "rating_comment": comment
        }

        self.counting(5)
        response = requests.post(api_connector, verify = False, headers = self.headers, json = bewertung_data)
        self.exit_check(response)

        print(response.json())
        sys.exit("Vielen Dank, dass Sie unseren Service genutzt haben & bis bald")




if __name__ == "__main__":
    c = Client()
    c.buchung()
    c.einsteigen()
    c.aussteigen()
    #todo -> Bewertungssystem funktioniert in der API noch nicht
    c.bewerten()

