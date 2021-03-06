from SCons.Defaults import Chmod
import SCons.Node.FS

csc = 'csc'
csc_flags = ['-optimize']
target_dest = 'builds/DECU_Fix'

# create an action for compiling the code
csharp_build = Builder( action = '$CSC $CSCFLAGS -out:${TARGET.abspath} $SOURCES',
                        source_factory=SCons.Node.FS.default_fs.Entry,
                        suffix='.exe')

# if the platform is linux add executable permissions
permissions = Builder(action = Chmod('${SOURCE.abspath}', 0o755))

# create an environment for compiling the code
env = Environment(CSC=csc, CSCFLAGS=csc_flags)

# link the environment and the action/builder
env.Append(BUILDERS = {'csharp_build' : csharp_build, 'permissions' : permissions})

# gather all files for compiling
# I should probably make a function that recusively walks the
# folders beneath src/ looking for *.cs files, but I'm lazy
compile_files = Glob('src/*.cs')

# Build the executable
csharp_exe = env.csharp_build(target_dest, compile_files)

# Give the executable permissions (dummy destination input is not used, 
# but the input is required to run the line)
exe_permissions = env.permissions('builds/dummy_dest', target_dest+'.exe')

# Make sure permissions come after building
env.Requires(exe_permissions, csharp_exe)