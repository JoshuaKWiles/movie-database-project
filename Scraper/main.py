from bs4 import BeautifulSoup
import requests
from difflib import SequenceMatcher
import os

def googlelink(movienme):
    temp = movienme.replace(" ", "+")
    link = 'https://google.com/search?q=' + str(temp) + "+imdb"
    #edit link accordingly
    return link


def buildgooglesoup(link):
    r = requests.get(link)
    soup = BeautifulSoup(r.text, 'html.parser')
    return soup


def getimdblink(movienme):
    imdblink = 'none'
    temp = ''
    googsoup = buildgooglesoup(googlelink(movienme))
    googsoup.prettify()
    for divone in googsoup.select('a[href*="imdb"]'):
        temp = divone.text.strip()
        if SequenceMatcher(None, temp, movienme).ratio() > .3 and 'title' in divone.get('href'):
            imdblink = divone.get('href')
            imdblink = imdblink.split('&', 1)[0]
            return imdblink
    return imdblink


moviename = ''

#with open('moviename.txt') as f:
#    moviename = f.read()
#os.remove('moviename.txt')

print('Enter movie name:')
moviename = input()
imdblink = getimdblink(moviename)
print(imdblink)

#with link scrape; description, actors, trailer, screenshots, facts, maybe similar movies? that may require a different site