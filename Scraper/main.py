from bs4 import BeautifulSoup
import requests
from urllib.request import Request, urlopen
from difflib import SequenceMatcher
import os
import re
import json

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
    result = []
    #for divone in imdbsoup.select('div', class_='sc-fa971bb0-0 faHifs'):
        #for divtwo in divone('div', class_='ipc-overflowText ipc-overflowText--pageSection ipc-overflowText--height-long ipc-overflowText--long ipc-overflowText--click ipc-overflowText--base'):
            #for divthree in divtwo('div', class_="ipc-html-content ipc-html-content--base"):
                #for divfour in divthree('div', class_="ipc-html-content-inner-div"):
                    #print('')
    for span in imdbsoup.select('span', class_='sc-5f699a2-0 kcphyk'):
        for a in span('a', class_='ipc-link ipc-link--baseAlt'):
            temp = a['href']
            temp = temp[11:]
            temp = 'plotsummary/' + temp
            doublesoup = buildsoup(imdblink + temp)
            doublesoup.prettify()
            for divone in doublesoup.select('div', class_='sc-f65f65be-0 fVkLRr'):
                for divtwo in divone('div', class_='ipc-html-content-inner-div'):
                    result.append(divtwo.text)
    try:
        return(result[len(result) - 1])
    except:
        return 'FIX ME'

def getactors(imdbsoup):
    imdbsoup.prettify()
    imglink = []
    actorname = []
    combined = []
    for section in imdbsoup.select('section', class_='ipc-page-section ipc-page-section--base sc-bfec09a1-0 gmonkL title-cast title-cast--movie  celwidget'):
        for div in section('div', class_='ipc-media ipc-media--avatar ipc-image-media-ratio--avatar ipc-media--base ipc-media--avatar-m ipc-media--avatar-circle ipc-avatar__avatar-image ipc-media__img'):
            for img in div.find_all('img', alt=True):
                actorname.append(img['alt'])
            for img in div.find_all('img', src=True):
                imglink.append(img['src'])
    for x in range(0, 10):
        combined.append(str(imglink[x]))
        combined.append(str(actorname[x]))
    return combined


def gettrailer(imdbsoup):
    imdbsoup.prettify()
    extension = ''
    vidlink = ''
    for divone in imdbsoup.select('div', class_='sc-385ac629-9 jiVoNU'):
        for a in divone('a', class_='ipc-btn ipc-btn--single-padding ipc-btn--center-align-content ipc-btn--default-height ipc-btn--core-baseAlt ipc-btn--theme-baseAlt ipc-btn--on-onBase ipc-secondary-button sc-f81a065-3 wHRmg'):
            if 'videogallery' in str(a['href']):
                extension = 'https://www.imdb.com/' + str(a['href'])
                splitlink = extension.split('?')
                extension = splitlink[0] + '/content_type-trailer/?' + splitlink[1]
                doublesoup = buildsoup(extension)
                doublesoup.prettify()
                for divtwo in doublesoup.select('div', class_='results-item slate'):
                    for atwo in divtwo('a', class_='video-modal'):
                        extension = atwo['href']
                        extension = extension[12:]
                        extension = 'https://www.imdb.com/video' + extension
                        splitatmark = extension.split('?')
                        extension = str(splitatmark[0]) + '/?' + str(splitatmark[1])
                        triplesoup = buildsoup(extension)
                        #results = re.search('{"mimeType":"video/mp4","url":"(.*)}', triplesoup)
                        #for result in results:
                            #print(str(result))
                        #for video in triplesoup.select('video', class_='jw-video jw-reset'):
                            #vidlink = video['src']
                        vidlink = triplesoup
                        break
                    if vidlink != '':
                        break
            if vidlink != '':
                break
    counter = 0
    soupfinal = vidlink
    vidlink = ''
    for script in soupfinal.select('script', id_='__NEXT_DATA__'):
        script.prettify()
        if counter == 69:
            parts = str(script).split(',')
            counter = 0
            for part in parts:
                if counter == 18:
                    vidlink = part[7:]
                    splitagain = vidlink.split(r'\u0026')
                    vidlink = splitagain[0] + '&amp;' + splitagain[1] + '&amp;' + splitagain[2]
                    vidlink = vidlink[:-1]
                    break
                counter = counter + 1
        counter = counter + 1
        if vidlink != '':
            break
    return vidlink

#beginning of main
moviename = 'Sonic the Hedgehog'
imdblink = getimdblink(moviename)
imdbsoup = buildsoup(imdblink)

#get description, store to string
description = getdescription(imdbsoup, imdblink)
#get actors info, store to list (format: linkactor1, nameactor1, linkactor2, nameactor2, etc)
actors = getactors(imdbsoup)
#get movietrailer source, store to string
trailer = gettrailer(imdbsoup)

#with link scrape; description, actors, trailer, screenshots, facts, maybe similar movies? that may require a different site