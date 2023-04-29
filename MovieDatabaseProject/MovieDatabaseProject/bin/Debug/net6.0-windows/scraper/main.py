import concurrent.futures

from bs4 import BeautifulSoup
from urllib.request import Request, urlopen
from difflib import SequenceMatcher
from concurrent.futures import ThreadPoolExecutor
import time
import os

global screenshotsoup


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
    try:
        while imdblink[0] != 'h':
            imdblink = imdblink[1:]
    except:
        return getimdblink(movienme + " imdb")
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

    try:
        for x in range(0, 10):
            combined.append(str(imglink[x]))
            combined.append(str(actorname[x]))
    except:
        return ['NULL', 'NULL']
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
                    try:
                        splitagain = vidlink.split(r'\u0026')
                        vidlink = splitagain[0] + '&amp;' + splitagain[1] + '&amp;' + splitagain[2]
                        vidlink = vidlink[:-1]
                    except:
                        vidlink = 'NULL'
                    break
                counter = counter + 1
        counter = counter + 1
        if vidlink != '':
            break
    return vidlink


def getscreenshots(imdbsoup):
    imdbsoup.prettify()
    found = ''
    imagelinks = []
    allimages = []
    for divone in imdbsoup.select('div', class_='sc-385ac629-9 jiVoNU'):
        for a in divone('a',class_='ipc-btn ipc-btn--single-padding ipc-btn--center-align-content ipc-btn--default-height ipc-btn--core-baseAlt ipc-btn--theme-baseAlt ipc-btn--on-onBase ipc-secondary-button sc-f81a065-3 wHRmg'):
            if 'mediaindex' in str(a['href']):
                extension = 'https://www.imdb.com/' + str(a['href'])
                found = extension
                break
        if found != '':
            break
    doublesoup = buildsoup(found)
    count = 0
    divimg = doublesoup.find('div', class_='media_index_thumb_list')
    for a in divimg('a'):
        if len(imagelinks) < 20:
            try:
                imagelinks.append('https://www.imdb.com' + a['href'])
            except:
                break
    pentuplethread = []
    pentuplesoup = []
    imgtemp = ''
    with ThreadPoolExecutor() as executor:
        for y in range(0, len(imagelinks)):
            pentuplethread.append(executor.submit(buildsoup, imagelinks[y]))
        for z in pentuplethread:
            pentuplesoup.append(z.result(timeout=8))
        for soup in pentuplesoup:
            for divtwo in soup.select('div', class_='sc-7c0a9e7c-2 kEDMKk'):
                for img in divtwo('img', class_='sc-7c0a9e7c-0 fEIEer'):
                    imgtemp = img['src']
                    break
                if imgtemp != '':
                    break
            allimages.append(imgtemp)
            imgtemp = ''
    while '' in allimages:
        allimages.remove('')
    return allimages


def gettrivia(imdblink):
    trivia = []
    tempone = ''
    triviasoup = buildsoup(imdblink + 'trivia/?ref_=tt_trv_trv')
    triviasoup = triviasoup.find('div', {'id': 'trivia_content'})
    soda = triviasoup.find('div', class_='list')
    count = 0
    sodas = triviasoup.find_all('div', {'class': 'sodatext'})
    for s in sodas:
        if count < 5:
            trivia.append(s.text.strip())
        count = count + 1
    for triv in trivia:
        triv.replace('/', '')
    return trivia


def getsimilarmovies(imdbsoup):
    imdbsoup.prettify()
    similar_movies = []
    movies = imdbsoup.find_all('span', {'data-testid': 'title'})
    for x in range(0, 3):
        similar_movies.append(movies[x].text)
    return similar_movies


#beginning of main

moviename = ''
with open('moviename.txt', 'r') as files:
    moviename = files.readline()

imdblink = getimdblink(moviename)
imdbsoup = buildsoup(imdblink)
mainthread = []

with ThreadPoolExecutor() as executor:
    mainthread.append(executor.submit(getdescription, imdbsoup, imdblink))
    mainthread.append(executor.submit(getactors, imdbsoup))
    mainthread.append(executor.submit(gettrailer, imdbsoup))
    mainthread.append(executor.submit(getscreenshots, imdbsoup))
    mainthread.append(executor.submit(gettrivia, imdblink))
    mainthread.append(executor.submit(getsimilarmovies, imdbsoup))

#get description, store to string
    description = mainthread[0].result()

#get actors info, store to list (format: linkactor1, nameactor1, linkactor2, nameactor2, etc)
    actors = mainthread[1].result()

#get movietrailer source, store to string
    trailer = mainthread[2].result()

#get screenshtos links, store to list
    screenshots = mainthread[3].result()

#get trivia, store strings in list
    trivia = mainthread[4].result()

#get similarmovies, store strings in list
    similarmovies = mainthread[5].result()


#description = string
#actors = list
#trailer = string
#screenshot = list
#trivia = list
#similarmovies = list
temp = ''

with open('description.txt', 'w') as files:
    files.write(description)

with open('actors.txt', 'w') as files:
    for x in range(0, len(actors)):
        if x % 2 == 0:
            temp = actors[x]
        if x % 2 == 1:
            temp = temp + ',' + actors[x]
            files.write(temp + '\n')
            temp = ''

with open('trailer.txt', 'w') as files:
    files.write(trailer)

with open('screenshots.txt', 'w') as files:
    for x in range(0, len(screenshots)):
        files.write(screenshots[x] + '\n')

with open('trivia.txt', 'w') as files:
    for x in range(0, len(trivia)):
        files.write(trivia[x] + '\n')

with open('similarmovies.txt', 'w') as files:
    for x in range(0, len(similarmovies)):
        files.write(similarmovies[x] + '\n')

os.remove('moviename.txt')

#with link scrape; description, actors, trailer, screenshots, facts, maybe similar movies? that may require a different site