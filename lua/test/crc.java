import java.io.*;
public class Test{
    public static int elfHash(byte[] data) {
        int hash = 0;
        int x;

        for (int i = 0; i < data.length; i++) {
            hash = (hash << 4) + data[i];
            if ((x = (int) (hash & 0xF0000000L)) != 0) {
                hash ^= (x >> 24);
                hash &= ~x;
            }
        }

        return hash & 0x7FFFFFFF;
    }
    public static void main(String[] args) throws IOException {
        String str1 = "132";
        String str2 = "asd";
        ByteArrayOutputStream os = new ByteArrayOutputStream();
        os.write(str1.getBytes());
        os.write(str2.getBytes());
        byte[] byteArray = os.toByteArray();
        System.out.println(new String(byteArray));
        System.out.println(elfHash(byteArray) + "");
    }
}
