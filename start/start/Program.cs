
int count;
int linenumber = 1;
string line;
while (linenumber <= 10)
{
    line = "";
    count = 0;
    while (count < 10)
    {
       line+= (count+1)*linenumber + (((count+1)*linenumber< 10) ? "  " : " ");
        count++;
    }
    Console.WriteLine(line);
    linenumber++;
}
