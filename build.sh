mkdir -p ./nuget

if ! test -n "$(find ./nuget -maxdepth 1 -name 'Uml.Robotics.Ros.Messages.*' -print -quit)"
then
    dotnet build Uml.Robotics.Ros.MessageBase -c Release
    cd ./YAMLParser
    dotnet run -- -m ../ -c Release -n Uml.Robotics.Ros.Messages -v 1.0.8 -o ../Uml.Robotics.Ros.Messages
    cd ../
    cp ./Uml.Robotics.Ros.Messages/bin/Release/*.nupkg ./nuget
fi

dotnet build -c Release