<b>Beware</b>: this tool deletes the source files and replaces them with .docx named files as it goes, even if the source file isn't really a text document. Don't run this on a OneDrive synced directory tree or it
is very likely to blow up the sync metadata files in there, and screw up all your data. Put the files you want to convert into a folder or folder tree all on their own, then copy the path into the proram and hit go.
I'm not responsible for all the inevitable damage this tool will undoubtedly do to all your data if you run it on any directory that isn't limited to ASCII formatted text files that you are ok with being deleted.
TO REPEAT: this tool deletes files as it goes and leaves you with the resulting converted files only. Only run this tool on copies of files, or files you don't care about.

I downloaded the Enron corpus to use as a proof of concept test for a file storage system I was evaluating, and found that all the files were just plain text ASCII with no extensions or formatting. 
It would be much more convenient for me if these were word docx format instead, so I wrote this little program to quickly crawl through the directory tree and convert each non docx file into a docx.
It tries to convert paragraphs of text into actual paragraphs, instead of hard limiting the text the 80 columns normally allowed in ascii email format. It also tries to preserve formatting for columnar data
and deliberately short sentences on lines without a blank line separating them. It's not particularly clever in how it does it, but it gets the job done well enough for a test set of documents.
