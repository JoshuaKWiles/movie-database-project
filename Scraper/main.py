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


def getdescription(imdbsoup, imdblink):
    imdbsoup.prettify()
    #for divone in imdbsoup.select('div', class_='sc-fa971bb0-0 faHifs'):
        #for divtwo in divone('div', class_='ipc-overflowText ipc-overflowText--pageSection ipc-overflowText--height-long ipc-overflowText--long ipc-overflowText--click ipc-overflowText--base'):
            #for divthree in divtwo('div', class_="ipc-html-content ipc-html-content--base"):
                #for divfour in divthree('div', class_="ipc-html-content-inner-div"):
                    #print('')
    for span in imdbsoup.select('span', class_='sc-5f699a2-0 kcphyk'):
        for a in span('a', class_='ipc-link ipc-link--baseAlt'):
            temp = a['href']
            temp = temp[11:]
            print(temp)
            temp = 'plotsummary/' + temp
            print(imdblink + temp)
            doublesoup = buildsoup(imdblink + temp)
            doublesoup.prettify()
            for divone in doublesoup.select('div', class_='sc-f65f65be-0 fVkLRr'):
                for divtwo in divone('div', class_='ipc-html-content-inner-div'):
                    print(divtwo.text)





def getactors(imdbsoup):
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
#get imdb link and build soup
imdblink = getimdblink(moviename)
imdbsoup = buildsoup(imdblink)

#get description, store to string
getdescription(imdbsoup, imdblink)
#get actors info, store to list
actors = getactors(imdbsoup)


#with link scrape; description, actors, trailer, screenshots, facts, maybe similar movies? that may require a different site