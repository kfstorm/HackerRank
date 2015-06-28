#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
#include <set>
using namespace std;

int main() {
    int t;
    cin >> t;
    for (auto tt = 0; tt < t; ++tt)
    {
        int n;
        long m;
        cin >> n >> m;
        set<long> sums;
        long result = 0, sum = 0;
        for (auto i = 0; i < n; ++i)
        {
            long a;
            cin >> a;
            sum = (sum + a) % m;
            if (sum > result) result = sum;
            auto it = sums.upper_bound(sum);
            if (it != sums.end())
            {
                auto next = *it;
                if (sum + m - next > result) result = sum + m - next;
            }
            sums.insert(sum);
        }
        cout << result << endl;
    }
    return 0;
}
