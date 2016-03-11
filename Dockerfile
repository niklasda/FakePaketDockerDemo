FROM mono
MAINTAINER niklasda

ADD ./build/FakeBuiltPaketPowered.exe /build/FakeBuiltPaketPowered.exe
ADD ./build/SomeLogic.dll /build/SomeLogic.dll

CMD [ "mono",  "./build/FakeBuiltPaketPowered.exe" ]