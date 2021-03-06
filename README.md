# DECU Spreadsheet Export Workaround

## Building

[Download and install](https://www.mono-project.com/download/stable/) the Mono compiler for your system.  This project was built and verified using version 6.12.0 Stable (6.12.0.122).

To build use the folowing command in the base folder of this project:

    scons -j128

To clean the build files use the following command:

    scons -c

## Running

Verify the file checksum before blindly using it.

| File | Algorithm | Hash |
| ---- | --------- | ---- |
| .\builds\DECU_Fix.exe | SHA256 | `92F811215DAAD0B286055ACC2DD2F0065416A5C24BE37868BCF4530EA1925A63` |

When running the C# executable ensure that you add executable permissions (Linux):

    chmod +x builds/DECU_Fix.exe

Then to run the executable:

    ./builds/DECU_Fix.exe .\path\to\files.csv .\path\to\dirs\that\contain\csv\files\