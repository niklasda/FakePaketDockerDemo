FROM mono
MAINTAINER niklasda

ADD ./build/FakeBuiltPaketPowered.exe /build/FakeBuiltPaketPowered.exe

CMD [ "mono",  "./build/FakeBuiltPaketPowered.exe" ]