# RunSharp
Simple program that allows you to run commands as another user without being prompted for their password. This is useful in cases where you don't always get feedback from a prompt, such as the case with some remote shells.

# Compilation
Compilation instructions will be made soon. For now, just grab the compiled binary under the Releases folder.

# Compatibility
Please note that even though the commands are given for other systems, this has only been tested on Windows 10 x64 at this time. It may work for other versions but no gaurentees for now. 

Will update this after testing.

# Usage
## Run Without Application Whitelisting Bypass
The following syntax is used to run the program without the Application Whitelisting Bypass Feature:

	> RunSharp.exe Domain UserName Password Command

Example:

	> RunSharp.exe CORP fmc defnotmypassword! "whoami >> c:\\Users\\Public\\test.txt"

## Run With Whitelisting Bypass (CURRENTLY NOT WORKING)
The following describes how to use the program with the InstallUtil Application Whitelisting (AWS) Bypass Technique.

Please note that the AWS bypass is only for running this program and not necessarily subsequent programs. You would need to chain together InstallUtil commands to make that happen.

The arguments Domain, Username, Password, and Command need to be contained in a file named input.txt. Each argument should be on its own line and the arguments should be in the order shown above. 

The input.txt file should be in the same directory as the RunSharp.exe program. 

Here is an example file:

	> CORP
    > fmc
    > defnotmypassword!
	> "whoami >> c:\\Users\\Public\\test.txt"

The following is the command used to run the program on Windows 7 x86:

	> C:\Windows\Microsoft.NET\Framework\v2.0.50727\InstallUtil.exe /LogToConsole=false /U RunSharp.exe

The following is the command used to run the program on Windows 7 x64:

	> C:\Windows\Microsoft.NET\Framework64\v2.0.50727\InstallUtil.exe /LogToConsole=false /U RunSharp.exe

The following is the command used to run the program on Windows 10 x86:

	> C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe /LogToConsole=false /U RunSharp.exe

The following is the command used to run the program on Windows 7 x64:

	> C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe /LogToConsole=false /U RunSharp.exe
