from bs4 import BeautifulSoup
from urllib.request import Request, urlopen

def get_source(url):
    req = Request(url, headers={'User-Agent': 'Mozilla/5.0'})
    webpage = urlopen(req).read()
    soup = BeautifulSoup(webpage, "html.parser")
    return soup


def findlinkext(moviename, iternum):
   if moviename[0] == ' ':
      moviename = moviename[1:]
   if moviename[len(moviename) - 1] == ' ':
      moviename = moviename[:-1]
   moviename = moviename.replace(' ', '+')
   soup = get_source('https://www.youtube.com/results?search_query=' + moviename + '+trailer')
   soup = soup.prettify()
   ind = soup.find(r'{"contents":[{"videoRenderer":{"videoId":')
   videoid = soup[ind + 42:ind + 53]
   if ind == -1:
      print('hi')
      if iternum == 20:
         return '-1'
      videoid = findlinkext(moviename, iternum + 1)
   link = 'https://www.youtube.com/embed/' + videoid
   return link


moviename = "Garfield A Tale of Two Kitties"
link = findlinkext(moviename, 0)

print(link)

