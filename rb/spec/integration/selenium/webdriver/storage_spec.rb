# encoding: utf-8
#
# Licensed to the Software Freedom Conservancy (SFC) under one
# or more contributor license agreements.  See the NOTICE file
# distributed with this work for additional information
# regarding copyright ownership.  The SFC licenses this file
# to you under the Apache License, Version 2.0 (the
# "License"); you may not use this file except in compliance
# with the License.  You may obtain a copy of the License at
#
#   http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing,
# software distributed under the License is distributed on an
# "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
# KIND, either express or implied.  See the License for the
# specific language governing permissions and limitations
# under the License.

require_relative 'spec_helper'

module Selenium::WebDriver::DriverExtensions
  describe HasWebStorage do

    compliant_on :browser => [:android] do
      shared_examples_for 'web storage' do
        before {
          driver.navigate.to url_for("clicks.html")
          storage.clear
        }

        it "can get and set items" do
          storage.should be_empty
          storage['foo'] = 'bar'
          storage['foo'].should == 'bar'

          storage['foo1'] = 'bar1'
          storage['foo1'].should == 'bar1'

          storage.size.should == 2
        end

        it "can get all keys" do
          storage['foo1'] = 'bar1'
          storage['foo2'] = 'bar2'
          storage['foo3'] = 'bar3'

          storage.size.should == 3
          storage.keys.should == %w[foo1 foo2 foo3]
        end

        it "can clear all items" do
          storage['foo1'] = 'bar1'
          storage['foo2'] = 'bar2'
          storage['foo3'] = 'bar3'

          storage.size.should == 3
          storage.clear
          storage.size.should == 0
          storage.keys.should be_empty
        end

        it "can delete an item" do
          storage['foo1'] = 'bar1'
          storage['foo2'] = 'bar2'
          storage['foo3'] = 'bar3'

          storage.size.should == 3
          storage.delete('foo1').should == 'bar1'
          storage.size.should == 2
        end

        it "knows if a key is set" do
          storage.should_not have_key('foo1')
          storage['foo1'] = 'bar1'
          storage.should have_key('foo1')
        end

        it "is Enumerable" do
          storage['foo1'] = 'bar1'
          storage['foo2'] = 'bar2'
          storage['foo3'] = 'bar3'

          storage.to_a.should == [
                                  ['foo1', 'bar1'],
                                  ['foo2', 'bar2'],
                                  ['foo3', 'bar3']
                                 ]
        end

        it "can fetch an item" do
          storage['foo1'] = 'bar1'
          storage.fetch('foo1').should == 'bar1'
        end

        it "raises IndexError on missing key" do
          lambda do
            storage.fetch('no-such-key')
          end.should raise_error(IndexError, /missing key/)
        end
      end

      context "local storage" do
        let(:storage) { driver.local_storage }
        it_behaves_like 'web storage'
      end

      context "session storage" do
        let(:storage) { driver.session_storage }
        it_behaves_like 'web storage'
      end
    end

  end
end
