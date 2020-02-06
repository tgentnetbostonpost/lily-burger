

RUN TESTS FROM IDE
1. Open BabySitterKata in .net.
2. In Visual Studio Choose Test on top menu then choose windows-> test explorer.
3. The test explorer will open up on the left side of the screen.
4. Right click on the Tests and choose run selected tests.

RUN TESTS FROM COMMAND LINE:
5. The VSTest.Console.exe is typically installed into the following path: C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow. When you run this tool, you need to prefix this path to the .exe, or add this path to the PATH environment variable.
6. Go to command prompt and navigate to folder where you VSTest.Console.exe is located and run VSTest.Console.exe [Path to Test DLL] BabySitterTests.dll