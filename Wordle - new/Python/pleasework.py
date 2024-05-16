# Import necessary libraries
print("Step 1")
import urllib.request
import json

# URL of the words.json file in the dwyl/english-words GitHub repository
print("Step 2")
url = "https://raw.githubusercontent.com/dwyl/english-words/master/words_dictionary.json"

# Use urllib to open the URL and load the JSON
print("Step 3")
response = urllib.request.urlopen(url)
data = json.load(response)

# Now 'data' is a dictionary where the keys are English words
print("Step 4")
words = list(data.keys())

# Create empty lists for 3, 4, 5, and 6 letter words
print("Step 5")
words_3 = []
words_4 = []
words_5 = []
words_6 = []

# Iterate over the words and add them to the appropriate list
print("Step 6")
for word in words:
    length = len(word)
    if length == 3:
        words_3.append(word)
    elif length == 4:
        words_4.append(word)
    elif length == 5:
        words_5.append(word)
    elif length == 6:
        words_6.append(word)

# Function to write words to a file
print("Step 7")
def write_words_to_file(filename, words):
    with open(filename, 'w') as f:
        for word in words:
            f.write(word + '\n')

# Write words to files
print("Step 8")
write_words_to_file('words_3.txt', words_3)
write_words_to_file('words_4.txt', words_4)
write_words_to_file('words_5.txt', words_5)
write_words_to_file('words_6.txt', words_6)
print("Done")