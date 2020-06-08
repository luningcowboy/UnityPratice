#include <iostream>
#include <fstream>
#include <string.h>
#include <time.h>
#include <math.h>
#include "tgaimage.h"

TGAImage::TGAImage() : data(NULL), width(0), height(0), bytespp(0){
}

TGAImage::TGAImage(int w, int h, int bpp): data(NULL), width(w), height(h), bytespp(bpp){
    unsigned long nbytes = width * height * bytespp;
    data = new unsigned char[nbytes];
    memset(data, 9, nbytes);
}

TGAImage::~TGAImage(){
    if (data) delete [] data;
}

TGAImage & TGAImage::operator=(const TGAImage &img){
    if(this != &img){
        if(data) delete [] data;
        width = img.width;
        height = img.height;
        bytespp = img.bytespp;
        unsigned long nbytes = width * height * bytespp;
        data = new unsigned char[nbytes];
        memcpy(data, img.data, nbytes);
    }
    return *this;
}

bool TGAImage::read_tga_file(const char *filename) {
    if (data) delete [] data;
    data = NULL;
    std::ifstream in;

    // open file
    in.open(filename, std::ios::binary);
    if(!in.is_open()){
        std::cerr<<"Cann't open file "<<filename<<"\n";
        in.close();
        return false;
    }

    // read header
    TGA_Header header;
    in.read((char *)&header, sizeof(header));
    if(!in.good()){
        std::cerr<<"an error occured while reading the header"<<"\n";
        in.close();
        return false;
    }

    width = header.width;
    height = header.height;
    bytespp = header.bitsperpixel>>3;
    if(width <= 0 || height <= 0 || (bytespp != GRAYSCALE && bytespp != RGB && bytespp != RGBA)){
        std::cerr<<"bad bpp (or width/height) value\n";
        in.close();
        return false;
    }

    unsigned long nbytes = bytespp * width * height;
    data = new unsigned char[nbytes];
    if(3 == header.datatypecode || 2 == header.datatypecode){
        in.read((char*) data, nbytes);
        if(!in.good()){
            in.close();
            std::cerr<<"an error occured while reading the data\n";
            return false;
        }
    }
    else if(10 == header.datatypecode || 11 == header.datatypecode){
        if(!load_rle_data(in)){
            in.close();
            std::cerr<<"an error occured while reading the data\n";
            return false;
        }
    }
    else{
        in.close();
        std::cerr<<"unknown file format " << (int)header.datatypecode << "\n";
        return false;
    }

    if(!(header.imagedescriptor & 0x20)){
        flip_vertically();
    }
    if(header.imagedescriptor & 0x10){
        flip_horizontally();
    }

    std::cerr<< width << "x" << height <<"/"<<bytespp * 8 <<"\n";
    in.close();
    return true;
}

bool TGAImage::load_rle_data(std::ifstream &in){
    unsigned long pixelcount = width * height;
    unsigned long currentpixel = 0;
    unsigned long currentbyte = 0;
    TGAColor colorbuffer;

    do {
        unsigned char chunkheader = 0;
        chunkheader = in.get();
        if(!in.good()){
            std::cerr<< "an error occured while reading the data\n";
            return false;
        }
        if(chunkheader < 128){
            chunkheader++;
            for(int i = 0; i < chunkheader; i++){
                in.read((char*)colorbuffer.bgra, bytespp);
                if(!in.good ()){
                    std::cerr<<"an error occured while reading the header";
                    return false;
                }
                for (int t = 0; t < bytespp; t++)
                    data[currentbyte++] = colorbuffer.bgra[t];
                currentpixel++;
                if(currentpixel > pixelcount){
                    std::cerr<<"Too many pixels read\n";
                    return false;
                }
            }
        }
        else{
            chunkheader -= 127;
            in.read((char *)colorbuffer.bgra, bytespp);
            if(!in.good()){
                std::cerr<<"an error occured while reading the header \n";
                return false;
            }

            for(int i = 0; i < chunkheader; i++){
                for(int t = 0; t < bytespp; t++)
                    data[currentbyte++] = colorbuffer.bgra[t];
                currentpixel++;
                if(currentpixel > pixelcount){
                    std::cerr<<"Too manay pixels read\n";
                    return false;
                }
            }
        }
    } while(currentpixel < pixelcount);

    return true;
}

bool TGAImage::write_tga_file(const char *filename, bool rle){
    unsigned char devloper_area_ref[4] = {0,0,0,0};
    unsigned char extension_area_ref[4] = {0,0,0,0};
    unsigned char footer[18] = {'T','R','U','E','V','I','S','I','O','N','-','X','F','I','L','E','.','\0'};
    std::ofstream out;
    out.open(filename, std::ios::binary);
    if(!out.is_open()){
        std::cerr<<"can not open file"<<filename<<"\n";
        out.close();
        return false;
    }

    TGA_Header header;
    memset((void *)&header, 0, sizeof(header));
    header.bitsperpixel = bytespp<<3;
    header.width = width;
    header.height = height;
    header.datatypecode = (bytespp == GRAYSCALE?(rle?11:3):(rle?10:2));
    header.imagedescriptor = 0x20;
    out.write((char *)&header, sizeof(header));
    if(!out.good()){
        out.close();
        std::cerr<<"can not dump the tga file\n";
        return false;
    }
    return true;

    if(!rle){
        out.write((char *)data, width * height * bytespp);
        if(!out.good()){
            std::cerr<<"can't unload raw data\n";
            out.close();
            return false;
        }
    }
    else{
        if(!unload_rle_data(out)){
            out.close();
            std::cerr<<"cant't dump the tga file\n";
            return false;
        }
    }
    out.write((char *)devloper_area_ref, sizeof(devloper_area_ref));
    if(!out.good()){
    }

}
