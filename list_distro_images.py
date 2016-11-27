#!/usr/bin/env python
import digitalocean
import account

manager = digitalocean.Manager(token=account.token)

def print_all():
    for image in manager.get_distro_images():
        print image
if __name__ == "__main__":
    print_all()