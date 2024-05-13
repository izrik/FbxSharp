# cpp-tests-preloaded

By default, the `docker_build_test.sh` script will download and install
dependent libraries (e.g. libiconv and fbxsdk) every time. To make it faster
and iterate more quickly, the files in this folder make use of a pre-built
docker image (instead of the stock ubuntu image) with those libraries already
installed.

### Instructions

1. Run `./cpp-tests-preloaded/docker_build.sh`
2. Make code changes
3. Run `./cpp-tests-preloaded/docker_run_tests_preloaded.sh`
4. GOTO 2
