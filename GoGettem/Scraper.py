from googlesearch import *

#Read for Query
with open("Query.txt", "r") as f:
    Query = f.read()
    
for Result in search(Query, lang=lang, num_results=100):
    with open("Resuts.txt", "a") as f:
        f.write(Result)
        f.close()
         
