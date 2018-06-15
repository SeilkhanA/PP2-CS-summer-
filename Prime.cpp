#include<iostream>

using namespace std;

	bool prime(int x){
		if(x == 1) return false;
		bool ok = true;
		for(int i = 2; i * i <= x; ++i){
			if(x % i == 0){
				ok = false;
				break;
			}
		}
		return ok;
	}


int main(){

int x;
cin >> x;

for(int i = 0; i <= x; ++i){
	if(prime(i)){
		cout << i << " ";
	}
}
	return 0;

}