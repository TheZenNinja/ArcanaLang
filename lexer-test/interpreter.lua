local tokens = {}

local fileName = "test"


local arcFile = fileName .. ".arc"
local outFile = fileName .. ".lua"

local lines = io.lines(arcFile)

for line in lines do
   ProcessLine(line)
end


function ProcessLine(line)
    line 
end
