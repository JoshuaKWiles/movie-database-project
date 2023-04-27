from bs4 import BeautifulSoup
import requests
from urllib.request import Request, urlopen
from difflib import SequenceMatcher
import os

def googlelink(movienme):
    temp = movienme.replace(" ", "+")
    link = 'https://google.com/search?q=' + str(temp) + "+imdb"
    #edit link accordingly
    return link


def buildsoup(link):
    req = Request(link , headers={'User-Agent': 'Mozilla/5.0'})
    webpage = urlopen(req).read()
    soup = BeautifulSoup(webpage, "html.parser")
    return soup


def getimdblink(movienme):
    imdblink = 'none'
    temp = ''
    googsoup = buildsoup(googlelink(movienme))
    googsoup.prettify()
    for divone in googsoup.select('a[href*="imdb"]'):
        temp = divone.text.strip()
        if SequenceMatcher(None, temp, movienme).ratio() > .3 and 'title' in divone.get('href'):
            imdblink = divone.get('href')
            imdblink = imdblink.split('&', 1)[0]
            while imdblink[0] != 'h':
                imdblink = imdblink[1:]
            return imdblink
    while imdblink[0] != 'h':
        imdblink = imdblink[1:]
    return imdblink


def getdescription(imdblink):
    imdbsoup = buildsoup(imdblink)
    imdbsoup.prettify()
    counter = 1
    imglink = []
    actorname = []
    combined = []
    for section in imdbsoup.select('section', class_='ipc-page-section ipc-page-section--base sc-bfec09a1-0 gmonkL title-cast title-cast--movie  celwidget'):
        for div in section('div', class_='ipc-media ipc-media--avatar ipc-image-media-ratio--avatar ipc-media--base ipc-media--avatar-m ipc-media--avatar-circle ipc-avatar__avatar-image ipc-media__img'):
            for img in div.find_all('img', alt=True):
                actorname.append(img['alt'])
                #print(img['alt'])
            for img in div.find_all('img', src=True):
                imglink.append(img['src'])
                #print(img['src'])
    for x in range(0, 10):
        combined.append(str(imglink[x]))
        combined.append(str(actorname[x]))
    return combined
#with open('moviename.txt') as f:
#    moviename = f.read()
#os.remove('moviename.txt')

moviename = 'The Terminator'
imdblink = getimdblink(moviename)
actors = getdescription(imdblink)


#with link scrape; description, actors, trailer, screenshots, facts, maybe similar movies? that may require a different site