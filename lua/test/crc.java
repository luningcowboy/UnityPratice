import java.io.*;
public class Test{
    public static int elfHash(byte[] data) {
        int hash = 0;
        int x = 0;

        for (int i = 0; i < data.length; i++) {
            // System.out.println("XXXXX:" + (hash << 4));
            hash = (hash << 4) + data[i];

            x = (int)(hash & 0xF0000000L);
            System.out.println(data[i] + "," + hash+ "," + x);
            if (x  != 0) {
                hash ^= (x >> 24);
                //System.out.println("hash:" + hash);
                hash &= ~x;
                //System.out.println("hash:" + hash);
            }
        }

        return hash & 0x7FFFFFFF;
    }
    public static void main(String[] args) throws IOException {
        String str1 = "33DH6DDE62D2$4E03BE41-641D-5C99-B378-89556BDB4E6C";
        //String str2 = "asd";
        ByteArrayOutputStream os = new ByteArrayOutputStream();
        os.write(str1.getBytes());
        //os.write(str2.getBytes());
        byte[] byteArray = os.toByteArray();
        System.out.println(new String(byteArray));
        System.out.println(elfHash(byteArray) + "");
    }
}
