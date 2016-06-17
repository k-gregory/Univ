import java.util.Arrays;
import java.util.Comparator;


public class Sorts {
    public static <T extends Comparable<T>> void knuthShellSort(T[] arr){
        int gap = 1;
        while (gap <= arr.length / 3)
            gap = gap*3 + 1;

        while (gap > 0){
            for(int i = gap;i < arr.length; i++){
                T tmp = arr[i];
                int j = i;
                for(; j>= gap && tmp.compareTo(arr[j-gap]) < 0; j-=gap){
                    arr[j] = arr[j-gap];
                }
                arr[j] = tmp;
            }
            gap = gap/3;
        }
    }

    public static <T extends Comparable<T>> void insertionSort(T[] arr){
        for(int i = 1; i < arr.length; i++){
            T tmp = arr[i];
            int j = i;
            for(; j >= 1 && tmp.compareTo(arr[j-1]) < 0; j--)
                arr[j] = arr[j-1];
            arr[j] = tmp;
        }
    }

    private static int radixCompareStrings(String s1, String s2, int pos){
        if(s1.length() <= pos && s2.length() <= pos) return 0;
        if(s1.length() <= pos) return -1;
        else if(s2.length() <= pos) return 1;
        else return Character.compare(s1.charAt(pos),s2.charAt(pos));
    }

    static int[] c = new int[Character.MAX_VALUE - Character.MIN_VALUE + 1];

    private static String[] radixCountingSort(String[] a, int pos){
        String[] b = new String[a.length];
        Arrays.fill(c, 0);

        for(int i = 0; i < a.length; i++){
            if(a[i].length() <= pos)
                c[0]++;
            else c[a[i].charAt(pos)+1]++;
        }

        for(int i = 1; i < c.length; i++)
            c[i] += c[i-1];

        for(int i = a.length - 1; i >= 0; i--){
            int p = a[i].length() > pos ? a[i].charAt(pos) + 1 : 0;
            c[p]--;
            b[c[p]] = a[i];
        }

        return b;
    }

    private static void radixInsertionSort(String[] arr, int pos){
        for(int i = 1; i < arr.length; i++){
            String v = arr[i];
            int j = i - 1;
            while (j>=0 && radixCompareStrings(arr[j],v,pos) > 0) {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j+1] = v;
        }
    }

    public static void lsd_radix_sort(String[] old_arr){
        String[] arr = old_arr;
        int maxLength = Arrays.stream(arr).map(String::length).max(Integer::compare).get();
        for(int pos =  maxLength - 1; pos >= 0; pos--) {
            //radixInsertionSort(old_arr, pos);
            arr = radixCountingSort(arr, pos);
        }
        System.arraycopy(arr,0,old_arr,0,arr.length);
    }
}
