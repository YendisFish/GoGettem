from googlesearch import *
import argsparse

#Handle arguments
parser = argparse.ArgumentParser()
parser.add_argument("-dat", help = "Data to be queried", required = true)
args = parser.parse_args()

Query = str(args.dat)
    
for Result in search(Query, lang=lang, num_results=100):
    with open("Resuts.txt", "a") as f:
        f.write(Result)
        f.close()
         
