import os
import yaml

def loadConfig(path):
    file = open(path)
    data = file.read()
    file.close()
    conf = yaml.load(data, yaml.FullLoader)
    print(conf)

loadConfig("../Assets/Scenes/main.unity")
