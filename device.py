import asyncio
import websockets
import json
import ssl
import pathlib
import requests
import string
import random
import os
from gpiozero import RGBLED

info = {
    'name': '',
    'devicetype': 'rgblight',
    'displayname': 'RGB Light',
    'settings': {
            'red': {'type': 'slider', 'value': '0'},
            'green': {'type': 'slider', 'value': '50'},
            'blue': {'type': 'slider', 'value': '173'}
    }
}

led = RGBLED(red=18, green=23, blue=24)
led.color = (1, 1, 1)

token = ''

passwordLocal = ''

uri = "ws://server:60648/api/devices/device/"
uriAuth = "ws://server:60648/api/devices/deviceAuth/"


async def consumer_handler(websocket: websockets.WebSocketClientProtocol) -> None:
    async for message in websocket:
        cleanedMessage = message.split("}")[0] + "}"
        print(cleanedMessage)
        await UpdateDeviceState(cleanedMessage, websocket)
        print(json.dumps(info))
        await websocket.send(json.dumps(info))


async def consume(token) -> None:
    websocket_resource_url = uri
    print(token)
    async with websockets.connect(websocket_resource_url, extra_headers={"Authorization": f"Bearer {token}"}) as websocket:
        print("ok")
        await websocket.send(json.dumps(info))
        okmsg = await websocket.recv()
        print(okmsg)
        await consumer_handler(websocket)


async def consumeAuth() -> None:
    websocket_resource_url = uriAuth
    async with websockets.connect(websocket_resource_url) as websocket:
        name = await websocket.recv()
        info['name'] = name
        await websocket.send(json.dumps(info))
        okmsg = await websocket.recv()
        global passwordLocal
        passwordLocal = GeneratePassword()
        print(passwordLocal)

        url = "http://server:60648/api/authenticate/register"

        payload = json.dumps({
            "username": info['name'],
            "email": "a@a.com",
            "password": passwordLocal,
            "role": "Device"
        })
        headers = {
            'Content-Type': 'application/json'
        }

        resp = requests.request(
            "POST", url, headers=headers, data=payload, verify=False)

        print(resp)
        await websocket.close()


async def UpdateDeviceState(data, websocket):
    if "\":\"" in data:
        settings = json.loads(data)
        for k, v in settings.items():
            info["settings"][k]["value"] = v
            
        red=int(info["settings"]["red"]["value"]) / 255
        green=int(info["settings"]["green"]["value"]) / 255
        blue=int(info["settings"]["blue"]["value"]) / 255
        led.color =(red, green, blue)
            
    elif data == 'delete}':
        file = open('./credentials.json', 'w')
        file.write('{"username":"","password":""}')
        file.close()
        
        info['name'] = ''
        passwordLocal = ''
        
        await websocket.close()
    else:
        info["displayname"] = data[0:-1]


def GeneratePassword():
    password = random.choice(string.ascii_lowercase)
    password += random.choice(string.ascii_uppercase)
    password += random.choice(string.digits)
    password += random.choice(string.punctuation)

    source = string.ascii_lowercase + string.ascii_uppercase + string.digits

    for i in range(10):
        password += random.choice(source)

    l = list(password)
    random.shuffle(l)
    password = ''.join(l)

    return password

if(not os.path.isfile('./credentials.json')):
    file = open('./credentials.json', 'w')
    file.write('{"username":"","password":""}')
    file.close()
    
file = open('./credentials.json', 'r')
credentials = json.loads(file.read())
file.close()

info['name'] = credentials['username']
passwordLocal = credentials['password']

while True:
    try:
        url = "http://server:60648/api/authenticate/login"
        print(info['name'])
        payload = json.dumps({
            "username": info['name'],
            "password": passwordLocal
        })
        headers = {
            'Content-Type': 'application/json'
        }

        loginresp = requests.request(
            "POST", url, headers=headers, data=payload, verify=False)

        print(loginresp)

        if loginresp.status_code != 200:
            try:
                loop = asyncio.get_event_loop()
                print("Register")
                loop.run_until_complete(consumeAuth())
                file = open('./credentials.json', 'w')
                file.write(json.dumps({"username": info['name'], "password": passwordLocal}))
                file.close()
            except Exception:
                pass
        else:
            token = loginresp.content.decode("utf-8")
            try:
                loop = asyncio.get_event_loop()
                loop.run_until_complete(consume(token))
                loop.run_forever()
            except Exception:
                pass
    except Exception:
        pass
